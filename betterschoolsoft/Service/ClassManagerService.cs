using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace betterschoolsoft.Service
{
    public class ClassManagerService
    {
        private readonly IUserStorageService _storage;

        public ClassManagerService(IUserStorageService storage)
        {
            _storage = storage;
        }

        public async Task<List<ClassGroup>> GetAllClassesAsync()
        {
            var users = await _storage.LoadAsync();
            return users
                .OfType<Students>()
                .Select(s => s.ClassGroup)
                .Distinct()
                .ToList();
        }

        public async Task CreateClassAsync(string name, Teachers classTeacher)
        {
            var users = await _storage.LoadAsync();

            var newClass = new ClassGroup(name, classTeacher);

            classTeacher.Subjects ??= new List<Subject>();

            await _storage.SaveAsync(users);
        }

        public async Task AddStudentToClassAsync(Students student, ClassGroup classGroup)
        {
            student.ClassGroup = classGroup;
            classGroup.Students.Add(student);

            var users = await _storage.LoadAsync();
            await _storage.SaveAsync(users);
        }

        public async Task AddTeacherToClassAsync(Teachers teacher, ClassGroup classGroup)
        {
            classGroup.Teachers.Add(teacher);

            var users = await _storage.LoadAsync();
            await _storage.SaveAsync(users);
        }
    }

}
