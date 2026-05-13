using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class ClassGroup
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        private string name = string.Empty;
        private Teachers classTeacher;
        private List<Students> students = new List<Students>();

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

                if (value.Length < 2)
                    throw new ArgumentException("Class name must be at least 2 characters.");

                name = value;
            }
        }

        public Teachers ClassTeacher
        {
            get => classTeacher;
            set
            {
                if (value == null)
                    throw new ArgumentException("Class teacher cannot be null.");

                classTeacher = value;
            }
        }

        public List<Students> Students
        {
            get => students;
            set
            {
                if (value == null)
                    throw new ArgumentException("Students list cannot be null.");

                students = value;
            }
        }

        public void AddStudent(Students student)
        {
            if (student == null)
                throw new ArgumentException("Student cannot be null.");

            students.Add(student);
        }

        public void RemoveStudent(Students student)
        {
            students.Remove(student);
        }


    }
}
