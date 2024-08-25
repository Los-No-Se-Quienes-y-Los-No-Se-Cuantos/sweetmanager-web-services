using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.Users.Work;

public interface IWorkerQueryService
{
    Task<Worker?> Handle(GetUserByIdQuery query);

    Task<Worker?> Handle(GetUserByEmailQuery query);

    Task<IEnumerable<Worker>> Handle(GetAllUsersQuery query);
}