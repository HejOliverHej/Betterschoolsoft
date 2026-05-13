using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Subject
    {
        private string name;

        [JsonConstructor]
        public Subject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Subject name cannot be empty.");
                name = value;
            }
        }
    }
}
