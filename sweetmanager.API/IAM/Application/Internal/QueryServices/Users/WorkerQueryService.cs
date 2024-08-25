using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.IAM.Domain.Services.Users.Work;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Users;

public class WorkerQueryService(IWorkerRepository workerRepository) : IWorkerQueryService
{
    public async Task<Worker?> Handle(GetUserByIdQuery query)
    {
        return await workerRepository.FindByIdAsync(query.Id);
    }

    public async Task<Worker?> Handle(GetUserByEmailQuery query)
    {
        return await workerRepository.FindByEmailAsync(query.Email);
    }

    public async Task<IEnumerable<Worker>> Handle(GetAllUsersQuery query)
    {
        return await workerRepository.ListAsync();
    }
}