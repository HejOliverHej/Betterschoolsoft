using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    abstract class Users
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        private string username = string.Empty;
        private string password = string.Empty;
        public enum UserRoll {Student, Teacher}

        

        protected Users(string username, string password)
        {
            Username = username;
            Password = password;
        }


        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");

                if (value.Length < 3)
                    throw new ArgumentException("Username must be at least 3 characters.");

                username = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password cannot be empty.");

                if (value.Length < 6)
                    throw new ArgumentException("Password must be at least 6 characters.");

                password = value;
            }
        }


    }
}
