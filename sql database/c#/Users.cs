using System;


namespace c_.Data
{
    class Users
    {
        public int Id {get ; set;}
        public string Name {get ; set;}
        public string LastName {get ; set;}

        public Users()
        {
            
        }

        public Users(string Name , string LastName)
        {
            this.Name = Name;
            this.LastName = LastName;
            
        }


        public override string ToString()
        {
            return Name + " " + LastName;
        }

    }
}
