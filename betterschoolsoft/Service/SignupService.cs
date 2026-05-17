using betterschoolsoft.Model;
using betterschoolsoft.Service;

public class SignupService
{
    private readonly IUserStorageService _storage;

    public SignupService(IUserStorageService storage)
    {
        _storage = storage;
    }

    public async Task<(bool success, string message)> CreateUserAsync(
        string username, string password, bool isTeacher, bool isStudent)
    {
        try
        {
            var users = await _storage.LoadAsync();

            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return (false, "Användarnamnet är redan taget!");

            Users newUser;

            if (isTeacher)
            {
                newUser = new Teachers(username, password);
            }
            else if (isStudent)
            {
                return (false, "Elever skapas via klasshantering, inte här.");
            }
            else
            {
                return (false, "Ingen roll vald.");
            }

            users.Add(newUser);
            await _storage.SaveAsync(users);

            return (true, "Konto skapat!");
        }
        catch (Exception ex)
        {
            return (false, $"Fel: {ex.Message}");
        }
    }
}
