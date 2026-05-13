using betterschoolsoft.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace betterschoolsoft.Service
{
    internal class UserService
    {
        private readonly string filePath;

        private readonly JsonSerializerOptions _options;

        public UserService()
        {
            filePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");

            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers =
                    {
                        ti =>
                        {
                            if (ti.Type == typeof(Users))
                            {
                                ti.PolymorphismOptions = new JsonPolymorphismOptions
                                {
                                    TypeDiscriminatorPropertyName = "$type",
                                    IgnoreUnrecognizedTypeDiscriminators = true,
                                    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType,
                                    DerivedTypes =
                                    {
                                        new JsonDerivedType(typeof(Students), "student"),
                                        new JsonDerivedType(typeof(Teachers), "teacher")
                                    }
                                };
                            }
                        }
                    }
                }
            };
        }

        public List<Users> GetUsers()
        {
            if (!File.Exists(filePath))
                return new List<Users>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Users>>(json, _options) ?? new List<Users>();
        }

        public void SaveUsers(List<Users> users)
        {
            var json = JsonSerializer.Serialize(users, _options);
            File.WriteAllText(filePath, json);
        }
    }
}
