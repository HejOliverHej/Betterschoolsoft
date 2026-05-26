using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace betterschoolsoft.Service
{
    public class ClassManagerService
    {
        private readonly IUserStorageService _userStorage;
        private readonly IClassStorageService _classStorage;

        public ClassManagerService(IUserStorageService userStorage, IClassStorageService classStorage)
        {
            _userStorage = userStorage;
            _classStorage = classStorage;
        }

        public async Task<List<ClassGroup>> GetAllClassesAsync()
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var teachers = users.OfType<Teachers>().ToList();
            var students = users.OfType<Students>().ToList();

            foreach (var c in classes)
            {
                c.ClassTeacher = teachers.FirstOrDefault(t => t.Id == c.ClassTeacherId);

                c.Students = new ObservableCollection<Students>(
                    students.Where(s => c.StudentIds.Contains(s.Id)));

                c.Teachers = new ObservableCollection<Teachers>(
                    teachers.Where(t => c.TeacherIds.Contains(t.Id)));
            }

            return classes;
        }

        public async Task CreateClassAsync(string name, Teachers classTeacher)
        {
            var classes = await _classStorage.LoadClassesAsync();

            var newClass = new ClassGroup(name, classTeacher);

            classes.Add(newClass);
            await _classStorage.SaveClassesAsync(classes);
        }

        public async Task AddStudentToClassAsync(Students student, ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target == null)
                return;

            if (!target.StudentIds.Contains(student.Id))
                target.StudentIds.Add(student.Id);

            var studentInStorage = users.OfType<Students>().FirstOrDefault(s => s.Id == student.Id);
            if (studentInStorage != null)
                studentInStorage.ClassGroupId = classGroup.Id;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }

        public async Task AddTeacherToClassAsync(Teachers teacher, ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target == null)
                return;

            if (!target.TeacherIds.Contains(teacher.Id))
                target.TeacherIds.Add(teacher.Id);

            var teacherInStorage = users.OfType<Teachers>().FirstOrDefault(t => t.Id == teacher.Id);
            if (teacherInStorage != null)
                teacherInStorage.ClassGroupId = classGroup.Id;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }
    }
}
