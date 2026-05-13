using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Classes
    {
        private int id;
        private string name = string.Empty;
        private string classteacher = string.Empty;

        public Classes(int id, string name, string classteacher)
        {
            Id = id;
            Name = name;
            Classteacher = classteacher;
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }
        public string Name
        {
            get { return name; }

            set { name = value; }
        }
        public string Classteacher
        {
            get { return classteacher; }

            set { classteacher = value; }
        }



    }
}
