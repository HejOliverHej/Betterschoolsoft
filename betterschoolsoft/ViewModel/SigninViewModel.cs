using betterschoolsoft.Model;
using betterschoolsoft.Service;
using betterschoolsoft.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    internal class SigninViewModel : BaseViewModel
    {
        private readonly UserService _userService = new();

        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";

        public bool IsStudent { get; set; }
        public bool IsTeacher { get; set; }

        public string Message { get; set; } = "";

        public ICommand SignUpCommand { get; }

        public SigninViewModel()
        {
            SignUpCommand = new Command(async () => await SignUp());
        }

        private async Task SignUp()
        {
            if (Password != ConfirmPassword)
            {
                Message = "Lösenorden matchar inte!";
                OnPropertyChanged(nameof(Message));
                return;
            }

            if (!IsStudent && !IsTeacher)
            {
                Message = "Välj en roll!";
                OnPropertyChanged(nameof(Message));
                return;
            }

            var users = _userService.GetUsers();

            Users newUser;

            if (IsTeacher)
            {
                newUser = new Teachers
                {
                    Id = users.Count + 1,
                    Username = Username,
                    Password = Password,
                    Subjects = new List<string>() 
                };
            }
            else
            {
                newUser = new Students
                {
                    Id = users.Count + 1,
                    Username = Username,
                    Password = Password,
                    Classid = "" 
                };
            }

            users.Add(newUser);
            _userService.SaveUsers(users);

            Message = "Konto skapat!";
            OnPropertyChanged(nameof(Message));

            await Task.Delay(800);

            await Shell.Current.GoToAsync("//LoginView");

        }
    }
}
