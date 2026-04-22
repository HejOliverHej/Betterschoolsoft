using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;


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
