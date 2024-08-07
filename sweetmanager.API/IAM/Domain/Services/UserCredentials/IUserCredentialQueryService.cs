using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials;

public interface IUserCredentialQueryService
{
    Task<UserCredential?> Handle(GetUserCredentialByUserIdQuery query);
}