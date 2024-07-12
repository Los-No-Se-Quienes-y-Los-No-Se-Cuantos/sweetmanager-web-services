using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash, string email)
{
    public int Id { get; }
    
    [MaxLength(50)]
    public string Username { get; private set; } = username;

    [MaxLength(50)]
    public string Email { get; private set; } = email;
    
    [JsonIgnore]
    public string PasswordHash { get; private set; } = passwordHash;

    public User() : this(string.Empty, string.Empty, string.Empty) { }
    
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