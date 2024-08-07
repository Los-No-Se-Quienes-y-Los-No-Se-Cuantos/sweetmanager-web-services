using System.ComponentModel.DataAnnotations;
using sweetmanager.API.IAM.Domain.Model.Entities;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates;

public partial  class User(string username, string email, Role role)
{
    public int Id { get; private set; }
    
    [MaxLength(50)]
    public string Username { get; private set; } = username;

    [MaxLength(50)]
    public string Email { get; private set; } = email;
    
    public User() : this(string.Empty,  string.Empty, Role.GetDefaultRole()) { }

    public Role Role { get; private set; } = role;

    public virtual UserCredential? UserCredential { get; private set; }
    
    public User UpdateUsername(string username)
    {
        Username = username;

        return this;
    }
}