using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace betterschoolsoft.Model
{

    public class ClassGroup
    {
        
            public Guid Id { get; set; }
            public string Name { get; set; }

            public Guid ClassTeacherId { get; set; }

            public List<Guid> StudentIds { get; set; } = new();
            public List<Guid> TeacherIds { get; set; } = new();

            [JsonIgnore]
            public ObservableCollection<Students> Students { get; set; } = new();

            [JsonIgnore]
            public ObservableCollection<Teachers> Teachers { get; set; } = new();

            [JsonIgnore]
            public Teachers ClassTeacher { get; set; }
        


        [JsonConstructor]
        public ClassGroup(Guid id, string name, Guid classTeacherId)
        {
            Id = id;
            Name = name;
            ClassTeacherId = classTeacherId;
        }

        public ClassGroup(string name, Teachers classTeacher)
        {
            Id = Guid.NewGuid();
            Name = name;
            ClassTeacher = classTeacher;
            ClassTeacherId = classTeacher.Id;
        }
    }


}
