using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    class Holder {
                
        private string name;
        private string nif;
        private string dateBirth;
        private string gender;

        public Holder(string name, string nif, string dateBirth, string gender)
        {
            this.name = name;
            this.nif = nif;
            this.dateBirth = dateBirth;
            this.gender = gender;
        }

        public string Name { get => name; set => name = value; }
        public string Nif { get => nif; set => nif = value; }
        public string DateBirth { get => dateBirth; set => dateBirth = value; }
        public string Gender { get => gender; set => gender = value; }

        public override string ToString()
        {
            return "\nName: " + Name +  "\nNif: " + Nif + "\nDateBirth: " + DateBirth + "\nGender: " + Gender;
        }
    }
}
