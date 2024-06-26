using BCryptNet = BCrypt.Net.BCrypt;

namespace sweetmanager.API.IAM.Infrastructure.Hashing.BCrypt.Services;

public class HashingServices
{
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}