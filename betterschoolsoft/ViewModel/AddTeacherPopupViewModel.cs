using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AddTeacherPopupViewModel : BaseViewModel
    {
        private readonly IUserStorageService _userStorage;

        public string TeacherName { get; set; }
        public string Password { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public AddTeacherPopupViewModel()
        {
            _userStorage = new JsonUserStorageService();

            AddCommand = new Command(async () => await AddTeacher());
            CancelCommand = new Command(() => CloseRequested?.Invoke());
        }

        private async Task AddTeacher()
        {
            

            try
            {
                var users = await _userStorage.LoadAsync();

                var newTeacher = new Teachers(TeacherName, Password);

                users.Add(newTeacher);
                await _userStorage.SaveAsync(users);

                CloseRequested?.Invoke();
            }
            catch (ArgumentException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", ex.Message, "OK");
            }
        }
    }
}

