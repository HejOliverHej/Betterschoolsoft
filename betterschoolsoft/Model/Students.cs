using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class Students : Users
    {
        public Guid? ClassGroupId { get; set; }   
        public List<Lesson> Lessons { get; set; }
        public List<Absence> Absences { get; set; }

        [JsonIgnore]
        public ClassGroup ClassGroup { get; set; } 

        [JsonConstructor]
        public Students(
            Guid id,
            string username,
            string password,
            Guid? classGroupId,
            List<Lesson> lessons,
            List<Absence> absences)
            : base(id, username, password)
        {
            ClassGroupId = classGroupId;
            Lessons = lessons ?? new List<Lesson>();
            Absences = absences ?? new List<Absence>();
        }

        public Students(string username, string password)
            : base(Guid.NewGuid(), username, password)
        {
            ClassGroupId = null;
            Lessons = new List<Lesson>();
            Absences = new List<Absence>();
        }

        public override string GetDashboardRoute()
        {
            return "//StudentSection/StudentDashboardView";
        }
    }

}
