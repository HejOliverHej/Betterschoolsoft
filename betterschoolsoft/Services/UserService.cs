using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using betterschoolsoft.Model;

namespace betterschoolsoft.Services;

public class UserService
{
    private readonly string filePath;

    public UserService()
    {
        filePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");
    }

    public List<User> GetUsers()
    {
        if (!File.Exists(filePath))
            return new List<User>();

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    public void SaveUsers(List<User> users)
    {
        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}