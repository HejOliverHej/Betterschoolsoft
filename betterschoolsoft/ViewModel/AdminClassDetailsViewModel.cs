using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminClassDetailsViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _storage;

        public ClassGroup Class { get; set; }

        public ICommand RenameClassCommand { get; }
        public ICommand ChangeTeacherCommand { get; }
        public ICommand AddStudentCommand { get; }
        public ICommand RemoveStudentCommand { get; }
        public ICommand AddTeacherCommand { get; }
        public ICommand RemoveTeacherCommand { get; }

        public AdminClassDetailsViewModel(ClassGroup classGroup)
        {
            Class = classGroup;

            _storage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());


            RenameClassCommand = new Command(async () => await RenameClass());
            ChangeTeacherCommand = new Command(async () => await ChangeTeacher());
            AddStudentCommand = new Command(async () => await AddStudent());
            RemoveStudentCommand = new Command<Students>(async (s) => await RemoveStudent(s));
            AddTeacherCommand = new Command(async () => await AddTeacher());
            RemoveTeacherCommand = new Command<Teachers>(async (t) => await RemoveTeacher(t));
        }

        private async Task RenameClass()
        {
            string newName = await Application.Current.MainPage.DisplayPromptAsync(
                "Byt namn", "Nytt klassnamn:");

            if (!string.IsNullOrWhiteSpace(newName))
            {
                Class.Name = newName;
                await _storage.SaveAsync(await _storage.LoadAsync());
                OnPropertyChanged(nameof(Class));
            }
        }

        private async Task ChangeTeacher()
        {
            var users = await _storage.LoadAsync();
            var teachers = users.OfType<Teachers>().ToList();

            string selected = await Application.Current.MainPage.DisplayActionSheet(
                "Välj ny klasslärare",
                "Avbryt",
                null,
                teachers.Select(t => t.Username).ToArray());

            if (selected != null)
            {
                Class.ClassTeacher = teachers.First(t => t.Username == selected);
                await _storage.SaveAsync(users);
                OnPropertyChanged(nameof(Class));
            }
        }

        private async Task AddStudent()
        {
            var users = await _storage.LoadAsync();
            var students = users.OfType<Students>()
                                .Where(s => s.ClassGroup.Name != Class.Name)
                                .ToList();

            string selected = await Application.Current.MainPage.DisplayActionSheet(
                "Välj elev",
                "Avbryt",
                null,
                students.Select(s => s.Username).ToArray());

            if (selected != null)
            {
                var student = students.First(s => s.Username == selected);
                Class.Students.Add(student);
                student.ClassGroup = Class;

                await _storage.SaveAsync(users);
                OnPropertyChanged(nameof(Class));
            }
        }

        private async Task RemoveStudent(Students student)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort elev",
                $"Vill du ta bort {student.Username} från klassen?",
                "Ja", "Nej");

            if (confirm)
            {
                Class.Students.Remove(student);
                await _storage.SaveAsync(await _storage.LoadAsync());
                OnPropertyChanged(nameof(Class));
            }
        }

        private async Task AddTeacher()
        {
            var users = await _storage.LoadAsync();
            var teachers = users.OfType<Teachers>()
                                .Where(t => !Class.Teachers.Contains(t))
                                .ToList();

            string selected = await Application.Current.MainPage.DisplayActionSheet(
                "Välj lärare",
                "Avbryt",
                null,
                teachers.Select(t => t.Username).ToArray());

            if (selected != null)
            {
                var teacher = teachers.First(t => t.Username == selected);
                Class.Teachers.Add(teacher);

                await _storage.SaveAsync(users);
                OnPropertyChanged(nameof(Class));
            }
        }

        private async Task RemoveTeacher(Teachers teacher)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort lärare",
                $"Vill du ta bort {teacher.Username} från klassen?",
                "Ja", "Nej");

            if (confirm)
            {
                Class.Teachers.Remove(teacher);
                await _storage.SaveAsync(await _storage.LoadAsync());
                OnPropertyChanged(nameof(Class));
            }
        }
    }
}
