using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Users;

public interface IWorkerRepository : IBaseRepository<Worker>
{
    Task<Worker?> FindByEmailAsync(string email);

    Task<bool> ExistByEmailAsync(string email);
}