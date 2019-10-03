using System.Linq;
using Newtonsoft.Json;

namespace Data
{
    public class Student
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Name {get ; set;}
        public string ClassDeg { get; set;}
        public string Location {get ; set;}
        public int Deg {get ; set;}

        public override string ToString() 
        {
            return JsonConvert.SerializeObject(this);
        } 

        public Student(string Name , string ClassDeg,string Location , int Deg)
        {
            this.Name = Name;
            this.ClassDeg = ClassDeg;
            this.Location = Location;
            this.Deg = Deg;
        }
    }

}