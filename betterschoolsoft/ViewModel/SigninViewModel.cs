using betterschoolsoft.Model;
using betterschoolsoft.Services;
using betterschoolsoft.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel;

public class SigninViewModel : INotifyPropertyChanged
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
            Message = "Passwords matchar inte!";
            OnPropertyChanged(nameof(Message));
            return;
        }

        var users = _userService.GetUsers();

        var role = IsTeacher ? "Teacher" : "Student";

        var newUser = new User
        {
            Id = users.Count + 1,
            Username = Username,
            Password = Password,
            Role = role
        };

        users.Add(newUser);
        _userService.SaveUsers(users);

        Message = "Konto skapat!";

        OnPropertyChanged(nameof(Message));


        await Task.Delay(800);


        Application.Current.MainPage = new NavigationPage(new LoginView());
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}