using System;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Data;

namespace Cosmos
{
    class Program
    {
        static string databaseName = "203";
        static string collectionName = "student";
        static string key="rjBdeS5FWLJElogeVmS1KyRi7YkeCJyUFTThaRy3Akc3yS7cejrmZ6DJWSXZLfUKNS9p8laaB32trNDrfilrcw==";
        static string endpoint = "https://d225396f-0ee0-4-231-b9ee.documents.azure.com:443/";
        public static DocumentClient client {get ; set;}

        public static Uri _uri = UriFactory.CreateDocumentCollectionUri(databaseName,collectionName);


        static void Main(string[] args)
        {
            client = new DocumentClient(new Uri(endpoint),key);

            Student aymen = new Student("Aymen jemi","Master","Tunis",2);
            Student salah = new Student("Sala7 Gra3","Master","Nabel",2);
            Student joujou = new Student("JouJOU","Licence","Mouritaniya",1);

            Student jdid = new Student("Jdid","Phd","Libia",2);

            // Insert(aymen);
            // Insert(salah);
            // Insert(joujou);

            //QueryByName("JouJOU");


             UpdateByName("Aymen jemi",jdid);

            client.Dispose();
        }

        public static void Insert(Student student)
        {
            var response = client.CreateDocumentAsync(
                _uri,
                student
            ).GetAwaiter().GetResult();

            Console.WriteLine(response.StatusCode);
        }

        public static void QueryByName(string name)
        {
            // or maxitemcount = -1 + inf
            FeedOptions feedOption = new FeedOptions{MaxItemCount = 100,EnableCrossPartitionQuery = true};
            IQueryable<Student> query = client.CreateDocumentQuery<Student>(_uri,feedOption)
                .Where(e => e.Name == name);

            foreach(Student student in query)
            {
                Console.WriteLine(student);
            }
            
        }

        public static void UpdateByName(string name , Student student)
        {
            FeedOptions feedOption = new FeedOptions{MaxItemCount = 100,EnableCrossPartitionQuery = true};

            var _student = client.CreateDocumentQuery<Student>(_uri,feedOption)
                                 .Where( s => s.Name == name)
                                 .AsEnumerable()
                                 .SingleOrDefault();

            Console.WriteLine(_student);
            
            var response = client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName,collectionName,_student.Id),student).GetAwaiter().GetResult();
            
            Console.WriteLine(response);

        }
    }
}
