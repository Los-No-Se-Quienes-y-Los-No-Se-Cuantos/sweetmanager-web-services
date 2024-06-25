namespace sweetmanager.API.IAM.Application.Internal.OutboundContext;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}