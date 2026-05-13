using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    internal class SignupService
    {
        private readonly IUserStorageService _storage;

        public SignupService(IUserStorageService storage)
        {
            _storage = storage;
        }

        public async Task<(bool success, string message)> CreateUserAsync(
            string username, string password, bool isStudent, bool isTeacher)
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
                else
                {
                    // Dummy teacher + class (tills du bygger riktig klasshantering)
                    var dummyTeacher = new Teachers("TempTeacher", "TempPassword");
                    var dummyClass = new ClassGroup("TempClass", dummyTeacher);

                    newUser = new Students(username, password, dummyClass);
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
}
