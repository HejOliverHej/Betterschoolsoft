using System.Text.Json;
using System.Text.Json.Serialization;
using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    public class JsonUserStorageService : IUserStorageService
    {
        private readonly string _filePath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
            IncludeFields = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonUserStorageService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");
        }

        public async Task SaveAsync(IEnumerable<Users> users)
        {
            var json = JsonSerializer.Serialize(users, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<IList<Users>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Users>();

            var json = await File.ReadAllTextAsync(_filePath);

            var rawList = JsonSerializer.Deserialize<List<JsonElement>>(json, _options);
            var users = new List<Users>();

            foreach (var element in rawList)
            {
                if (!element.TryGetProperty("Role", out var roleProp))
                    continue;

                var role = roleProp.GetString();

                Users u = role switch
                {
                    "Student" => element.Deserialize<Students>(_options),
                    "Teacher" => element.Deserialize<Teachers>(_options),
                    _ => null
                };

                if (u != null)
                    users.Add(u);
            }

            return users;
        }
    }
}
