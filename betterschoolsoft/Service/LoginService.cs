using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    internal class LoginService
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
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }
    }
}
