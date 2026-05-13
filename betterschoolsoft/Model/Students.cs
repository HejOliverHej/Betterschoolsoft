using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Students : Users
    {
        private ClassGroup classGroup;
        private List<Lesson> lessons;
        private List<Absence> absences;

        [JsonConstructor]
        public Students(
            Guid id,
            string username,
            string password,
            ClassGroup classGroup,
            List<Lesson> lessons,
            List<Absence> absences)
            : base(id, username, password)
        {
            ClassGroup = classGroup;
            Lessons = lessons ?? new List<Lesson>();
            Absences = absences ?? new List<Absence>();
        }

        public Students(string username, string password, ClassGroup classGroup)
            : base(Guid.NewGuid(), username, password)
        {
            ClassGroup = classGroup;
            Lessons = new List<Lesson>();
            Absences = new List<Absence>();
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
            set => lessons = value ?? new List<Lesson>();
        }

        public List<Absence> Absences
        {
            get => absences;
            set => absences = value ?? new List<Absence>();
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
