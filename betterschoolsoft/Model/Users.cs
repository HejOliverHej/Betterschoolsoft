using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    abstract class Users
    {

        private int id;
        private string username = string.Empty;
        private string password = string.Empty;
        public enum UserRoll {Student, Teacher}


        protected Users(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }


        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        public string Username
        {
            get { return username; }

            set { username = value; }
        }
        public string Password
        {
            get { return password; }

            set { password = value; }
        }
    }
}
