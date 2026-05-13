using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Subject
    {

        public Guid Id { get; private set; } = Guid.NewGuid();

        private string name = string.Empty;

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

                if (value.Length < 2)
                    throw new ArgumentException("Subject name must be at least 2 characters.");

                name = value;

            }
        }
    }
}