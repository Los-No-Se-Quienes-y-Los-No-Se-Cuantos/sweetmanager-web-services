using System.Text.Json.Serialization;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public int Id { get; }
    public string Username { get; private set; } = username;

    [JsonIgnore]
    public string PasswordHash { get; private set; } = passwordHash;

    public User() : this(string.Empty, string.Empty) { }
    public User UpdateUsername(string username)
    {
        Username = username;

        return this;
    }
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;

        return this;
    }
}