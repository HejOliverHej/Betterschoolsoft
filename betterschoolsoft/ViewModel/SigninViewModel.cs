using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class SigninViewModel : BaseViewModel
    {
        private readonly SignupService _signupService;

        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";

        public bool IsStudent { get; set; }
        public bool IsTeacher { get; set; }

        public bool IsAdmin { get; set; }

        private string _message = "";
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand SignUpCommand { get; }

        public SigninViewModel()
        {
            _signupService = new SignupService(new JsonUserStorageService());
            SignUpCommand = new Command(async () => await SignUp());
        }

        private async Task SignUp()
        {
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 2)
            {
                Message = "Användarnamnet måste vara minst 2 tecken.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 2)
            {
                Message = "Lösenordet måste vara minst 2 tecken.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Lösenorden matchar inte!";
                return;
            }

            if (!IsStudent && !IsTeacher && !IsAdmin)
            {
                Message = "Välj en roll!";
                return;
            }

            var result = await _signupService.CreateUserAsync(
                Username, Password, IsStudent, IsTeacher, IsAdmin);

            Message = result.message;

            if (result.success)
            {
                await Task.Delay(800);
                await Shell.Current.GoToAsync("//LoginView");
            }
        }
    }
}
