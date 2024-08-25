using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.IAM.Domain.Services.Users.Administration;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Users;

internal class AdministratorQueryService(IAdministratorRepository administratorRepository) : IAdministratorQueryService
{
    public async Task<Administrator?> Handle(GetUserByIdQuery query)
        => await administratorRepository.FindByIdAsync(query.Id);
    

    public async Task<Administrator?> Handle(GetUserByEmailQuery query)
        => await administratorRepository.FindByEmailAsync(query.Email);
    

    public async Task<IEnumerable<Administrator>> Handle(GetAllUsersQuery query)
        => await administratorRepository.ListAsync();
    

    public async Task<int> Handle(GetUserIdByEmailQuery query)
        => await administratorRepository.FindIdByEmailAsync(query.Email);
}