using sweetmanager.API.IAM.Domain.Model.Aggregates;

namespace sweetmanager.API.IAM.Application.Internal.OutboundContext;

public interface ITokenService
{
    string GenerateToken(dynamic user);
    
    dynamic? ValidateToken(string? token);
}