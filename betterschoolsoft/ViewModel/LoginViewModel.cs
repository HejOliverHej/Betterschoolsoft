using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        /*
        private readonly LoginService _loginService;

        private string _username;
        private string _password;

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
                await Shell.Current.GoToAsync("//SignupView");

            });
        }

        private async Task Login()
        {
            var user = await _loginService.LoginAsync(Username, Password);

            if (user == null)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Fel användarnamn eller lösenord", "OK");
                return;
            }

            if (user.Role == Users.UserRole.Student)
            {
                await Shell.Current.GoToAsync("//StudentSection/StudentDashboardView");
            }
            else if (user.Role == Users.UserRole.Teacher)
            {
                await Shell.Current.GoToAsync("//TeacherSection/TeacherDashboardView");
            }
        }

        */

    }
}
