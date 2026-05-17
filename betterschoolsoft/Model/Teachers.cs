using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Teachers : Users
    {
        private List<Subject> subjects;

        [JsonConstructor]
        public Teachers(
            Guid id,
            string username,
            string password,
            List<Subject> subjects)
            : base(id, username, password)
        {
            Subjects = subjects ?? new List<Subject>();
        }

        public Teachers(string username, string password)
            : base(username, password)
        {
            Subjects = new List<Subject>();
        }

        public List<Subject> Subjects
        {
            get => subjects;
            set => subjects = value ?? new List<Subject>();
        }
        public override string GetDashboardRoute()
        {
            return "//TeacherSection/TeacherDashboardView";
        }

    }

}
