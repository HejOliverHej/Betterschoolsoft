using betterschoolsoft.Model;
using betterschoolsoft.Service;
using betterschoolsoft.View;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace betterschoolsoft.ViewModel
{
    public class AdminAddTeachersAndStudentsViewmodel : BaseViewModel
    {
        
        private readonly IUserStorageService _userStorage;

        public ObservableCollection<Students> Students { get; set; }
        public ObservableCollection<Teachers> Teachers { get; set; }

        public ICommand AddStudentCommand { get; }
        public ICommand RemoveStudentCommand { get; }
        public ICommand AddTeacherCommand { get; }
        public ICommand RemoveTeacherCommand { get; }

        public AdminAddTeachersAndStudentsViewmodel()
        {
            _userStorage = new JsonUserStorageService();

            Students = new ObservableCollection<Students>();
            Teachers = new ObservableCollection<Teachers>();

            AddStudentCommand = new Command(async () => await OpenAddStudentPopup());
            RemoveStudentCommand = new Command<Students>(async s => await RemoveStudent(s));
            AddTeacherCommand = new Command(async () => await OpenAddTeacherPopup());
            RemoveTeacherCommand = new Command<Teachers>(async t => await RemoveTeacher(t));

            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await _userStorage.LoadAsync();

            Students.Clear();
            foreach (var s in users.OfType<Students>())
                Students.Add(s);

            Teachers.Clear();
            foreach (var t in users.OfType<Teachers>())
                Teachers.Add(t);
        }

        private async Task OpenAddStudentPopup()
        {
            var popup = new AddStudentPopup();
            var vm = new AddStudentPopupViewModel(null); // ingen klass

            popup.BindingContext = vm;

            vm.CloseRequested += () =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
                LoadUsers();
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private async Task RemoveStudent(Students student)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort elev",
                $"Vill du ta bort {student.Username} helt?",
                "Ja", "Nej");

            if (!confirm) return;

            var users = await _userStorage.LoadAsync();
            users = users.Where(u => u.Id != student.Id).ToList();


            await _userStorage.SaveAsync(users);

            LoadUsers();
        }

        private async Task OpenAddTeacherPopup()
        {
            var popup = new AddTeacherPopup();
            var vm = new AddTeacherPopupViewModel(); 

            popup.BindingContext = vm;

            vm.CloseRequested += () =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
                LoadUsers();
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private async Task RemoveTeacher(Teachers teacher)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Ta bort lärare",
                $"Vill du ta bort {teacher.Username} helt?",
                "Ja", "Nej");

            if (!confirm) return;

            var users = await _userStorage.LoadAsync();
            users = users.Where(u => u.Id != teacher.Id).ToList();


            await _userStorage.SaveAsync(users);

            LoadUsers();

           

        }

    }
}
