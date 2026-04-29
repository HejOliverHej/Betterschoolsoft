using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace betterschoolsoft.Model
{
    internal class Teachers : Users
    {

        private List<string> subjects = new List<string>();
        public Teachers(int id, string username, string password, string subjects, UserRole role)
            : base(id, username, password, role)
        {
            Subjects = subjects.Split(',').ToList();;
        }


        public List<string> Subjects
        {
            get { return subjects; }

            set { subjects = value; }
        }

    }
}
