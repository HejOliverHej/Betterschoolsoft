using betterschoolsoft.Model;
using betterschoolsoft.Service;
using betterschoolsoft.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminClassDetailsViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _userStorage;

        public ClassGroup Class { get; set; }

        public ObservableCollection<Students> AvailableStudents { get; set; }
        public ObservableCollection<Teachers> AvailableTeachers { get; set; }

        public ICommand RemoveStudentCommand { get; }
        public ICommand RemoveTeacherCommand { get; }

        public ObservableCollection<Teachers> AvailableMentors { get; set; }

        private Teachers _selectedMentor;
        public Teachers SelectedMentor
        {
            get => _selectedMentor;
            set
            {
                _selectedMentor = value;
                OnPropertyChanged(nameof(SelectedMentor));
            }
        }

        private Students _selectedStudentToAdd;
        public Students SelectedStudentToAdd
        {
            get => _selectedStudentToAdd;
            set
            {
                _selectedStudentToAdd = value;
                OnPropertyChanged(nameof(SelectedStudentToAdd));
            }
        }

        private Teachers _selectedTeacherToAdd;
        public Teachers SelectedTeacherToAdd
        {
            get => _selectedTeacherToAdd;
            set
            {
                _selectedTeacherToAdd = value;
                OnPropertyChanged(nameof(SelectedTeacherToAdd));
            }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand AddTeacherCommand { get; }

        public ICommand SaveChangesCommand { get; }


        public AdminClassDetailsViewModel(ClassGroup classGroup)
        {
            _userStorage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                _userStorage,
                new JsonClassStorageService());

            Class = classGroup;

            Class.Students ??= new ObservableCollection<Students>();
            Class.Teachers ??= new ObservableCollection<Teachers>();

            SaveChangesCommand = new Command(async () => await SaveChanges());


            RemoveStudentCommand = new Command<Students>(async (s) => await RemoveStudent(s));
            RemoveTeacherCommand = new Command<Teachers>(async (t) => await RemoveTeacher(t));


            AddStudentCommand = new Command(async () => await AddStudent());
            AddTeacherCommand = new Command(async () => await AddTeacher());



            LoadAvailableUsers();
        }

        private async void LoadAvailableUsers()
        {
            var users = await _userStorage.LoadAsync();

            var allStudents = users.OfType<Students>().ToList();
            var allTeachers = users.OfType<Teachers>().ToList();

            AvailableStudents = new ObservableCollection<Students>(
                allStudents.Where(s => s.ClassGroupId == null));
            OnPropertyChanged(nameof(AvailableStudents));

            AvailableTeachers = new ObservableCollection<Teachers>(
                allTeachers.Where(t =>
                    t.Id != Class.ClassTeacherId &&
                    !Class.Teachers.Any(ct => ct.Id == t.Id)));
            OnPropertyChanged(nameof(AvailableTeachers));

            AvailableMentors = new ObservableCollection<Teachers>(
    users.OfType<Teachers>()
         .Where(t => t.Id != Class.ClassTeacherId)); 

            OnPropertyChanged(nameof(AvailableMentors));


        }

        private async Task AddStudent()
        {
            if (SelectedStudentToAdd == null)
                return;

            await _classService.AddStudentToClassAsync(SelectedStudentToAdd, Class);

            SelectedStudentToAdd.ClassGroupId = Class.Id;
            Class.Students.Add(SelectedStudentToAdd);
            AvailableStudents.Remove(SelectedStudentToAdd);

            SelectedStudentToAdd = null;
        }

        private async Task AddTeacher()
        {
            if (SelectedTeacherToAdd == null)
                return;

            await _classService.AddTeacherToClassAsync(SelectedTeacherToAdd, Class);

            Class.Teachers.Add(SelectedTeacherToAdd);
            AvailableTeachers.Remove(SelectedTeacherToAdd);

            SelectedTeacherToAdd = null;
        }

        private async Task RemoveStudent(Students student)
        {
            if (student == null)
                return;

            await _classService.RemoveStudentFromClassAsync(student, Class);

            Class.Students.Remove(student);
            AvailableStudents.Add(student);
        }

        private async Task RemoveTeacher(Teachers teacher)
        {
            if (teacher == null)
                return;

            await _classService.RemoveTeacherFromClassAsync(teacher, Class);

            Class.Teachers.Remove(teacher);
            AvailableTeachers.Add(teacher);
        }

        private async Task SaveChanges()
        {
            if (SelectedMentor != null && SelectedMentor.Id != Class.ClassTeacherId)
            {
                await _classService.ChangeClassTeacherAsync(Class, SelectedMentor);

                Class.ClassTeacher = SelectedMentor;
                Class.ClassTeacherId = SelectedMentor.Id;
            }


            await Application.Current.MainPage.DisplayAlert("Sparat", "Ändringarna har sparats.", "OK");
            await Shell.Current.GoToAsync("//AdminSection/AdminClassView");

        }


    }
}
