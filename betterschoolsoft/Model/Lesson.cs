using System;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Lesson
    {
        private string title;
        private Subject subject;

        [JsonConstructor]
        public Lesson(string title, Subject subject)
        {
            Title = title;
            Subject = subject;
        }

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Lesson title cannot be empty.");
                title = value;
            }
        }

        public Subject Subject
        {
            get => subject;
            set => subject = value ?? throw new ArgumentException("Subject cannot be null.");
        }
    }
}
