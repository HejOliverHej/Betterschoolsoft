using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginService _loginService;

        private string _username = "";
        private string _password = "";

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand GoToSignupCommand { get; }

        public LoginViewModel()
        {

            _loginService = new LoginService(new JsonUserStorageService());

            LoginCommand = new Command(async () => await Login());
            GoToSignupCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//SigninView");
            });
        }

        private async Task Login()
        {


            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Fyll i alla fält", "OK");
                return;
            }

            var user = await _loginService.LoginAsync(Username, Password);

            if (user == null)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Fel användarnamn eller lösenord", "OK");
                return;
            }

            await Shell.Current.GoToAsync(user.GetDashboardRoute());





          
        }
    }
}
