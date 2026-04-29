using System;
using System.Collections.Generic;
using System.Linq;

namespace betterschoolsoft.Model
{
    internal class Teachers : User
    {
        public List<string> Subjects { get; set; } = new List<string>();

        public Teachers(int id, string username, string password, string subjects)
            : base(username, password, "Teacher")
        {
            Id = id;
            Subjects = subjects.Split(',').ToList();
        }
    }
}