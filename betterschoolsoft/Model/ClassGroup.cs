using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{
    public class ClassGroup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        [JsonIgnore]
        public Teachers ClassTeacher { get; set; }

        [JsonIgnore]
        public List<Students> Students { get; set; } = new();

        [JsonIgnore]
        public List<Teachers> Teachers { get; set; } = new();

        [JsonConstructor]
        public ClassGroup(Guid id, string name)
        {
            Id = id;
            Name = name;
            Students = new List<Students>();
            Teachers = new List<Teachers>();
        }

        public ClassGroup(string name, Teachers classTeacher)
        {
            Id = Guid.NewGuid();
            Name = name;
            ClassTeacher = classTeacher;
            Students = new List<Students>();
            Teachers = new List<Teachers>() { classTeacher };
        }
    }
}
