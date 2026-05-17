using betterschoolsoft.Model;
using System.Collections.Generic;
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
            return await _classStorage.LoadClassesAsync();
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

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target != null)
            {
                target.Students.Add(student);
                student.ClassGroup = target;
            }

            await _classStorage.SaveClassesAsync(classes);

            var users = await _userStorage.LoadAsync();
            await _userStorage.SaveAsync(users);
        }

        public async Task AddTeacherToClassAsync(Teachers teacher, ClassGroup classGroup)
        {
            var classes = await _classStorage.LoadClassesAsync();

            var target = classes.FirstOrDefault(c => c.Id == classGroup.Id);
            if (target != null)
            {
                target.Teachers.Add(teacher);
            }

            await _classStorage.SaveClassesAsync(classes);
        }
    }
}
