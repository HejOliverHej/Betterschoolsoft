using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace betterschoolsoft.Service
{

    /// <summary>
    /// Om jag bara sammafattar hela denna fill så är det all logik bakom 
    /// sparningen av klassen ClassGroup jag tycker att alla methoder är ganska själv sägande.
    /// Till sist har jag valt att anvädna mig av tre filler istället för två när det kommer 
    /// till sparningen av typ allt och det är för att jag separerar logiken bakom sparningen och själva sparandet för att lättare läsa koden.
    /// </summary>
    public class ClassManagerService
    {
        private readonly IUserStorageService _userStorage;
        private readonly IClassStorageService _classStorage;

        public ClassManagerService(IUserStorageService userStorage, IClassStorageService classStorage)
        {
            _userStorage = userStorage;
            _classStorage = classStorage;
        }


        /// <summary>
        /// häntar alla nuvarande skol klasser fårn storage. kör när adminsction öppnar adminclassview
        /// </summary>
        /// <returns>Skol klasser</returns>
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


        public async Task RemoveStudentFromClassAsync(Students student, ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target == null)
                return;

            target.StudentIds.Remove(student.Id);

            var studentInStorage = users.OfType<Students>().FirstOrDefault(s => s.Id == student.Id);
            if (studentInStorage != null)
                studentInStorage.ClassGroupId = null;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }

        public async Task RemoveTeacherFromClassAsync(Teachers teacher, ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target == null)
                return;

            target.TeacherIds.Remove(teacher.Id);

            var teacherInStorage = users.OfType<Teachers>().FirstOrDefault(t => t.Id == teacher.Id);
            if (teacherInStorage != null)
                teacherInStorage.ClassGroupId = null;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }

        public async Task ChangeClassTeacherAsync(ClassGroup classGroup, Teachers newTeacher)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target == null)
                return;

            target.ClassTeacherId = newTeacher.Id;

            var teacherInStorage = users.OfType<Teachers>().FirstOrDefault(t => t.Id == newTeacher.Id);
            if (teacherInStorage != null)
                teacherInStorage.ClassGroupId = classGroup.Id;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }

        public async Task DeleteClassAsync(ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();
            var users = await _userStorage.LoadAsync();

            classes.RemoveAll(c => c.Id == classGroup.Id);

            foreach (var student in users.OfType<Students>().Where(s => s.ClassGroupId == classGroup.Id))
                student.ClassGroupId = null;

            foreach (var teacher in users.OfType<Teachers>().Where(t => t.ClassGroupId == classGroup.Id))
                teacher.ClassGroupId = null;

            await _classStorage.SaveClassesAsync(classes);
            await _userStorage.SaveAsync(users);
        }



    }
}
