using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Students : Users
    {

        private string classid = string.Empty;
        public Students(int id, string username, string password, string classid, UserRole role)
            : base(id, username, password, role)
        {
            Classid = classid;
        }


        public string Classid
        {
            get { return classid; }

            set { classid = value; }
        }

    }
}
