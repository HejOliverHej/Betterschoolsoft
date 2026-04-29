using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    public class LoginService
    {
        private readonly IUserStorageService _storage;

        public LoginService(IUserStorageService storage)
        {
            _storage = storage;
        }

        public async Task<Users?> LoginAsync(string username, string password)
        {
            var users = await _storage.LoadAsync();

            return users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);
        }
    }
}
