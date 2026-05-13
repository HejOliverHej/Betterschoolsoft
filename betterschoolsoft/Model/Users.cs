using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public abstract class Users
    {
        public Guid Id { get; private set; }

        private string username;
        private string password;

        [JsonConstructor]
        protected Users(Guid id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        protected Users(string username, string password)
        {
            Id = Guid.NewGuid();
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
                password = value;
            }
        }
    }
}
