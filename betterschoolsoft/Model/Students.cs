using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Students : User
    {

        private string classid = string.Empty;
        public Students(int id, string username, string password, string classid)
    : base(username, password, "Student")
        {
            Id = id;
            Classid = classid;
        }


        public string Classid
        {
            get { return classid; }

            set { classid = value; }
        }

    }
}
