
using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Lesson
    {

        public Guid Id { get; private set; } = Guid.NewGuid();

        private Subject subject;
        private Teachers teacher;
        private ClassGroup classGroup;

        private string room = string.Empty;
        private DayOfWeek weekday;
        private TimeSpan startTime;
        private TimeSpan endTime;

        public Lesson(Subject subject, Teachers teacher, ClassGroup classGroup,
                      string room, DayOfWeek weekday, TimeSpan startTime, TimeSpan endTime)
        {
            Subject = subject;
            Teacher = teacher;
            ClassGroup = classGroup;
            Room = room;
            Weekday = weekday;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Subject Subject
        {
            get => subject;
            set
            {
                if (value == null)
                    throw new ArgumentException("Subject cannot be null.");

                subject = value;
            }
        }

        public Teachers Teacher
        {
            get => teacher;
            set
            {
                if (value == null)
                    throw new ArgumentException("Teacher cannot be null.");

                teacher = value;
            }
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

        public string Room
        {
            get => room;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Room cannot be empty.");

                room = value;
            }
        }

        public DayOfWeek Weekday
        {
            get => weekday;
            set => weekday = value;
        }

        public TimeSpan StartTime
        {
            get => startTime;
            set
            {
                if (value < TimeSpan.FromHours(6) || value > TimeSpan.FromHours(20))
                    throw new ArgumentException("Start time must be between 06:00 and 20:00.");

                startTime = value;
            }
        }

        public TimeSpan EndTime
        {
            get => endTime;
            set
            {
                if (value <= StartTime)
                    throw new ArgumentException("End time must be after start time.");

                endTime = value;
            }
        }

    }
}
