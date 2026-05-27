using betterschoolsoft.Model;
using betterschoolsoft.Service;

public class LoginService
{
    private readonly IUserStorageService _storage;

    public LoginService(IUserStorageService storage)
    {
        _storage = storage;
    }


    /// <summary>
    /// loginasync som även har hårdkodat in det ända admin konton viste inte bågpt annat sätt att göra det på.
    /// </summary>
    
    public async Task<Users> LoginAsync(string username, string password)
    {
        if (username == "admin" && password == "admin123")
        {
            return new Admin("admin", "admin123");
        }

        var users = await _storage.LoadAsync();

        return users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);
    }
}
