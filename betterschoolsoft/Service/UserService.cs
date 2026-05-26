using betterschoolsoft.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace betterschoolsoft.Service
{
    internal class JsonUserStorageService : IUserStorageService
    {
        private readonly string filePath;
        private readonly JsonSerializerOptions _options;

        public JsonUserStorageService()
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
                                        new JsonDerivedType(typeof(Students), "betterschoolsoft.Model.Students, betterschoolsoft"),
                                        new JsonDerivedType(typeof(Teachers), "betterschoolsoft.Model.Teachers, betterschoolsoft"),
                                        new JsonDerivedType(typeof(Admin), "betterschoolsoft.Model.Admin, betterschoolsoft")


                                    }
                                };
                            }
                        }
                    }
                }
            };
        }

        public async Task<IList<Users>> LoadAsync()
        {
            if (!File.Exists(filePath))
                return new List<Users>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<Users>>(json, _options) ?? new List<Users>();
        }

        public async Task SaveAsync(IEnumerable<Users> users)
        {
            var json = JsonSerializer.Serialize(users, _options);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
