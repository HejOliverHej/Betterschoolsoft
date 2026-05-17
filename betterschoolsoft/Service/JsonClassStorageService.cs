using betterschoolsoft.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace betterschoolsoft.Service
{
    public class JsonClassStorageService : IClassStorageService
    {
        private readonly string _filePath = Path.Combine(
            FileSystem.AppDataDirectory, "classes.json");

        public async Task<List<ClassGroup>> LoadClassesAsync()
        {
            if (!File.Exists(_filePath))
                return new List<ClassGroup>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<ClassGroup>>(json)
                   ?? new List<ClassGroup>();
        }

        public async Task SaveClassesAsync(List<ClassGroup> classes)
        {
            var json = JsonSerializer.Serialize(classes, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
