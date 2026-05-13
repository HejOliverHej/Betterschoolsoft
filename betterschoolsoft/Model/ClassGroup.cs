using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class ClassGroup
    {
        private string name;
        private Teachers classTeacher;

        [JsonConstructor]
        public ClassGroup(string name, Teachers classTeacher)
        {
            Name = name;
            ClassTeacher = classTeacher;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Class name cannot be empty.");
                name = value;
            }
        }

        public Teachers ClassTeacher
        {
            get => classTeacher;
            set => classTeacher = value ?? throw new ArgumentException("ClassTeacher cannot be null.");
        }
    }
}
