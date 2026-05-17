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
            string username, string password, bool isStudent, bool isTeacher, bool isAdmin)
        {
            try
            {
                var users = await _storage.LoadAsync();

                if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                    return (false, "Användarnamnet är redan taget!");

                Users newUser;

                if (isAdmin)
                {
                    newUser = new Admin(username, password);
                }
                else if (isTeacher)
                {
                    newUser = new Teachers(username, password);
                }
                else if (isStudent)
                {
                    // Dummy till jag skapar system för att lägga till lärare till klasser och lärare till dem
                    var dummyTeacher = new Teachers("TempTeacher", "TempPassword");
                    var dummyClass = new ClassGroup("TempClass", dummyTeacher);

                    newUser = new Students(username, password, dummyClass);
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
}
