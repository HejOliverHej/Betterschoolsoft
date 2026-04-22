
using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Lesson
    {

        private int id;
        private Subject subject;
        private string teacher = string.Empty;
        private string classRoom = string.Empty;
        private string startTime = string.Empty;
        private string endTime = string.Empty;
        private string weekday = string.Empty;
        private string classid = string.Empty;

        public Lesson(int id, string teacher, string classRoom, string startTime, string endTime, string weekday, string classid)
        {
            Id = id;
            Teacher = teacher;
            ClassRoom = classRoom;
            StartTime =  startTime;
            EndTime = endTime;
            Weekday = weekday;
            Classid = classid;
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }
        public string Teacher
        {
            get { return teacher; }

            set { teacher = value; }
        }
        public string ClassRoom
        {
            get { return classRoom; }

            set { classRoom = value; }
        }
        public string StartTime
        {
            get { return startTime; }

            set { startTime = value; }
        }
        public string EndTime
        {
            get { return endTime; }

            set { endTime = value; }
        }
        public string Weekday
        {
            get { return weekday; }

            set { weekday = value; }
        }
        public string Classid
        {
            get { return classid; }

            set { classid = value; }
        }


    }
}
