using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash, string email, Role role)
{
    public int Id { get; private set; }
    
    [MaxLength(50)]
    public string Username { get; private set; } = username;

    [MaxLength(50)]
    public string Email { get; private set; } = email;
    
    [JsonIgnore]
    public string PasswordHash { get; private set; } = passwordHash;

    public User() : this(string.Empty, string.Empty, string.Empty, Role.GetDefaultRole()) { }

    public Role Role { get; private set; } = role;
    
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