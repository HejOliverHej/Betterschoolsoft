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
        private DateTime date;
        private int amount;

        public Absence(int id, int studentid, int lessonid, DateTime date, int amount)
        {
            Id = id;
            Studentid = studentid;
            Lessonid = lessonid;
            Date = date;
            Amount = amount;
        }

        public int Id
        {
            get { return id; }

            set { id = value; }
        }
        public int Amount
        {
            get { return amount; }

            set { amount = value; }
        }
        public DateTime Date
        {
            get { return date; }

            set { date = value; }
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
