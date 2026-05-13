using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Absence
    {

            public Guid Id { get; private set; } = Guid.NewGuid();

            private Students student;
            private Lesson lesson;
            private DateTime date;
            private int minutes;

            public Absence(Students student, Lesson lesson, DateTime date, int minutes)
            {
                Student = student;
                Lesson = lesson;
                Date = date;
                Minutes = minutes;
            }

            public Students Student
            {
                get => student;
                set
                {
                    if (value == null)
                        throw new ArgumentException("Student cannot be null.");

                    student = value;
                }
            }

            public Lesson Lesson
            {
                get => lesson;
                set
                {
                    if (value == null)
                        throw new ArgumentException("Lesson cannot be null.");

                    lesson = value;
                }
            }

            public DateTime Date
            {
                get => date;
                set
                {
                    if (value == default)
                        throw new ArgumentException("Date cannot be empty.");

                    date = value;
                }
            }

            public int Minutes
            {
                get => minutes;
                set
                {
                    if (value < 1)
                        throw new ArgumentException("Absence minutes must be at least 1.");

                    if (value > 600)
                        throw new ArgumentException("Absence minutes cannot exceed 600 (10 hours).");

                    minutes = value;
                }
            }
    }
}




