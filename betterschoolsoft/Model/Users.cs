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


        /// <summary>
        /// jag ser nu att jag inte använder mig av denna vaildering för att jag andlig skapar ett object men
        /// hjälpa av inlogningen så jag kan inte använda mig av try ctachs.
        /// </summary>
        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be empty.");
                if (value.Contains(" "))
                    throw new ArgumentException("Username cannot be have space in it.");
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
                if (value.Contains(" "))
                    throw new ArgumentException("Password cannot be have space in it.");
                password = value;
            }
        }

        public abstract string GetDashboardRoute(); // här är lite polyformism för att det skulle vara med 

    }
}
