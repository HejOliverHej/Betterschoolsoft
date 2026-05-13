using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace betterschoolsoft.Model
{
    internal class Teachers : Users
    {

        private List<Subject> subjects = new List<Subject>();

        public Teachers(string username, string password)
            : base(username, password)
        {
        }

        public Teachers(string username, string password, List<Subject> subjects)
            : base(username, password)
        {
            Subjects = subjects;
        }

        public List<Subject> Subjects
        {
            get => subjects;
            set
            {
                if (value == null)
                    throw new ArgumentException("Subjects list cannot be null.");

                subjects = value;
            }
        }

        public void AddSubject(Subject subject)
        {
            if (subject == null)
                throw new ArgumentException("Subject cannot be null.");

            subjects.Add(subject);
        }

        public void RemoveSubject(Subject subject)
        {
            subjects.Remove(subject);


        }
    }
}
