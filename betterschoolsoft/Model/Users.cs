using System;
using System.Collections.Generic;
using System.Text;
using static betterschoolsoft.Model.Users;

namespace betterschoolsoft.Model
{
    abstract class Users
    {

        private int id;
        private string username = string.Empty;
        private string password = string.Empty;
        public enum UserRole {Student, Teacher}

        public UserRole role;




        protected Users(int id, string username, string password, UserRole role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }


        public UserRole Role
        {
            get { return role; }

            set { role = value; }
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
