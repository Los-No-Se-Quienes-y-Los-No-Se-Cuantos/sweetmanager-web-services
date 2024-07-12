using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    
    Task<User?> Handle(GetUserByEmailQuery query);
    
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}