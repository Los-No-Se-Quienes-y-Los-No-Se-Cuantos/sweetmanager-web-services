using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Clients.Domain.Model.Aggregates;
namespace sweetmanager.API.Clients.Domain.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
    }
}