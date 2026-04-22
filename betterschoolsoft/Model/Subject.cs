using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Subject
    {

        private int id;
        private string name = string.Empty;

        public Subject(int id, string name, string classteacher)
        {
            Id = id;
            Name = name;
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
    }
}
