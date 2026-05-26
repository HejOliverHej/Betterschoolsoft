using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AddStudentPopupViewModel : BaseViewModel
    {
        private readonly ClassGroup? _class;
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _userStorage;

        public string StudentName { get; set; }

        public string Password { get; set; }   

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public AddStudentPopupViewModel(ClassGroup? classGroup)
        {
            _class = classGroup;

            _userStorage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());

            AddCommand = new Command(async () => await AddStudent());
            CancelCommand = new Command(() => CloseRequested?.Invoke());
        }

        private async Task AddStudent()
        {
            

            try
            {
                var users = await _userStorage.LoadAsync();

                var newStudent = new Students(StudentName, Password);

                if (_class != null)
                {
                    newStudent.ClassGroup = _class;
                    _class.Students.Add(newStudent);

                    await _classService.AddStudentToClassAsync(newStudent, _class);

                }

                users.Add(newStudent);
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
