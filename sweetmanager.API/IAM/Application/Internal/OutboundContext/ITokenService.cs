using sweetmanager.API.IAM.Domain.Model.Aggregates;

namespace sweetmanager.API.IAM.Application.Internal.OutboundContext;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}