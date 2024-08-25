using System.ComponentModel.DataAnnotations;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Entities.User;

public class User(string username, string email, Role role, string name, string surname, string phoneNumber)
{
    public CompleteName Name { get; private set; } = new (name.ToUpper(), surname.ToUpper());
    
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Username { get; private set; } = username;

    [MaxLength(50)]
    public string Email { get; private set; } = email;
    
    public User() : this(string.Empty,  string.Empty, Role.GetDefaultRole(), string.Empty,string.Empty, "") { }

    public Role Role { get; private set; } = role;
    
    public User UpdateUsername(string username)
    {
        Username = username;

        return this;
    }
    
    [MaxLength(25)]
    public string PhoneNumber { get; private set; } = phoneNumber;
}