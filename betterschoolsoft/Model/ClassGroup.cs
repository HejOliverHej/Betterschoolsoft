using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class ClassGroup
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonConstructor]
        public ClassGroup(Guid id, string name, Teachers classTeacher, List<Students> students, List<Teachers> teachers)
        {
            Id = id;
            Name = name;
            ClassTeacher = classTeacher;
            Students = students ?? new List<Students>();
            Teachers = teachers ?? new List<Teachers>();
        }

        public ClassGroup(string name, Teachers classTeacher)
        {
            Id = Guid.NewGuid();
            Name = name;
            ClassTeacher = classTeacher;
            Students = new List<Students>();
            Teachers = new List<Teachers>() { classTeacher };
        }

        public string Name { get; set; }
        public Teachers ClassTeacher { get; set; }
        public List<Students> Students { get; set; }
        public List<Teachers> Teachers { get; set; }
    }
}
