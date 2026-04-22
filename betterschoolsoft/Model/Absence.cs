using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Model
{
    internal class Absence
    {

        private int id;
        private int studentid;
        private int lessonid; 
        private DatePicker date;

        public Absence(int id, int studentid, int lessonid)
        {
            Id = id;
            Studentid = studentid;
            Lessonid = lessonid;
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }
        public int Studentid
        {
            get { return studentid; }

            set { studentid = value; }
        }
        public int Lessonid
        {
            get { return lessonid; }

            set { lessonid = value; }
        }
    }
}
