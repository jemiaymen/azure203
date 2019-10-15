using System;
using c_.Data;
using System.Data.SqlClient;

namespace c_
{
    class Program
    {
        private static string constr = "Server=tcp:203.database.windows.net,1433;Initial Catalog=203;Persist Security Info=False;User ID=su;Password=Admin100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
            var conn = new SqlConnection(constr);
            // var aymen = new Users("Aymen","Jemi");
            // Console.WriteLine("______-----Jemix -----_________");
            // Console.WriteLine(aymen);
            

            // var cmd = new SqlCommand("INSERT Users(Name,LastName) VALUES(@1,@2)",conn);
            // cmd.Parameters.AddWithValue("@1",aymen.Name);
            // cmd.Parameters.AddWithValue("@2",aymen.LastName);
            // Console.WriteLine("______-----Open Connection-----_________");
            // conn.Open();

            // Console.WriteLine("______-----Run Query-----_________");
            // cmd.ExecuteNonQuery();
            // conn.Close();

            var cmd = new SqlCommand("SELECT * FROM Users",conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("id : {0}, Name : {1} , LastName : {2}", reader[0] , reader[1] , reader[2]));
            }
            conn.Close();
        }
    }
}
