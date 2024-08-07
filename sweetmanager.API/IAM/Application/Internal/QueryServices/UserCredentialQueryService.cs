using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.IAM.Domain.Services.UserCredentials;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices;

internal class UserCredentialQueryService(IUnitOfWork unitOfWork, IUserCredentialRepository userCredentialRepository) : IUserCredentialQueryService 
{
    public async Task<UserCredential?> Handle(GetUserCredentialByUserIdQuery query)
    {
        return await userCredentialRepository.FindByUserIdAsync(query.UserId);
    }
}