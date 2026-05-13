using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Students : Users
    {

        private ClassGroup classGroup;
        private List<Lesson> lessons = new List<Lesson>();
        private List<Absence> absences = new List<Absence>();

        public Students(string username, string password, ClassGroup classGroup)
            : base(username, password)
        {
            ClassGroup = classGroup;
        }

        public ClassGroup ClassGroup
        {
            get => classGroup;
            set
            {
                if (value == null)
                    throw new ArgumentException("ClassGroup cannot be null.");

                classGroup = value;
            }
        }

        public List<Lesson> Lessons
        {
            get => lessons;
            set
            {
                if (value == null)
                    throw new ArgumentException("Lessons list cannot be null.");

                lessons = value;
            }
        }

        public List<Absence> Absences
        {
            get => absences;
            set
            {
                if (value == null)
                    throw new ArgumentException("Absences list cannot be null.");

                absences = value;
            }
        }

        public void AddLesson(Lesson lesson)
        {
            if (lesson == null)
                throw new ArgumentException("Lesson cannot be null.");

            lessons.Add(lesson);
        }

        public void AddAbsence(Absence absence)
        {
            if (absence == null)
                throw new ArgumentException("Absence cannot be null.");

            absences.Add(absence);
        }
    }

}

