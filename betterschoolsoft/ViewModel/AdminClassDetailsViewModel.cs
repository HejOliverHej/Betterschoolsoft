using betterschoolsoft.Model;
using betterschoolsoft.Service;
using betterschoolsoft.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminClassDetailsViewModel : BaseViewModel
    {

        /*
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _userStorage;

        public ClassGroup Class { get; }

        public string EditableClassName { get; set; }

        public ObservableCollection<Students> Students { get; set; }
        public ObservableCollection<Teachers> Teachers { get; set; }
        public ObservableCollection<Teachers> AllTeachers { get; set; }

        public Teachers SelectedClassTeacher { get; set; }

        public ICommand AddStudentCommand { get; }
        public ICommand RemoveStudentCommand { get; }
        public ICommand AddTeacherCommand { get; }
        public ICommand RemoveTeacherCommand { get; }
        public ICommand SaveChangesCommand { get; }

        public AdminClassDetailsViewModel(ClassGroup classGroup)
        {
            Class = classGroup;

            EditableClassName = Class.Name;

            _userStorage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());

            Students = new ObservableCollection<Students>(Class.Students);
            Teachers = new ObservableCollection<Teachers>(Class.Teachers);

            LoadAllTeachers();

            SelectedClassTeacher = Class.ClassTeacher;

            AddStudentCommand = new Command(async () => await OpenAddStudentPopup());
            RemoveStudentCommand = new Command<Students>(async s => await RemoveStudent(s));
            AddTeacherCommand = new Command(async () => await OpenAddTeacherPopup());
            RemoveTeacherCommand = new Command<Teachers>(async t => await RemoveTeacher(t));
            SaveChangesCommand = new Command(async () => await SaveChanges());
        }

        private async void LoadAllTeachers()
        {
            var users = await _userStorage.LoadAsync();
            AllTeachers = new ObservableCollection<Teachers>(users.OfType<Teachers>());
        }

        // -----------------------------
        // ADD STUDENT POPUP
        // -----------------------------
        private async Task OpenAddStudentPopup()
        {
            var popup = new AddStudentPopup();
            var vm = new AddStudentPopupViewModel(Class);

            popup.BindingContext = vm;

            vm.CloseRequested += () =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
                RefreshStudents();
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private void RefreshStudents()
        {
            Students = new ObservableCollection<Students>(Class.Students);
            OnPropertyChanged(nameof(Students));
        }

        private async Task RemoveStudent(Students student)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort elev",
                $"Vill du ta bort {student.Username} från klassen?",
                "Ja", "Nej");

            if (!confirm) return;

            Class.Students.Remove(student);
            student.ClassGroup = null;

            RefreshStudents();
        }

        // -----------------------------
        // ADD TEACHER POPUP
        // -----------------------------
        private async Task OpenAddTeacherPopup()
        {
            var popup = new AddTeacherPopup();
            var vm = new AddTeacherPopupViewModel(Class);

            popup.BindingContext = vm;

            vm.CloseRequested += () =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
                RefreshTeachers();
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private void RefreshTeachers()
        {
            Teachers = new ObservableCollection<Teachers>(Class.Teachers);
            OnPropertyChanged(nameof(Teachers));
        }

        private async Task RemoveTeacher(Teachers teacher)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort lärare",
                $"Vill du ta bort {teacher.Username} från klassen?",
                "Ja", "Nej");

            if (!confirm) return;

            Class.Teachers.Remove(teacher);
            RefreshTeachers();
        }

        // -----------------------------
        // SAVE CHANGES
        // -----------------------------
        private async Task SaveChanges()
        {
            Class.Name = EditableClassName;
            Class.ClassTeacher = SelectedClassTeacher;
            Class.Students = Students.ToList();
            Class.Teachers = Teachers.ToList();

            var classes = await _classService.GetAllClassesAsync();
            var target = classes.First(c => c.Id == Class.Id);

            target.Name = Class.Name;
            target.ClassTeacher = Class.ClassTeacher;
            target.Students = Class.Students;
            target.Teachers = Class.Teachers;

            await _classService.SaveClassesAsync(classes);

            await Application.Current.MainPage.DisplayAlert("Sparat", "Ändringar sparade!", "OK");
        }
        */
    }
}
