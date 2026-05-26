using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using betterschoolsoft.Model;

namespace betterschoolsoft.Service
{
    public class JsonMessageStorageService : IMessageStorageService
    {
        private readonly string _filePath = Path.Combine(
            FileSystem.AppDataDirectory, "messages.json");

        public async Task<List<Message>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Message>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Message>>(json)
                   ?? new List<Message>();
        }

        public async Task SaveAsync(List<Message> messages)
        {
            var json = JsonSerializer.Serialize(messages, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(_filePath, json);
        }
    }

}
