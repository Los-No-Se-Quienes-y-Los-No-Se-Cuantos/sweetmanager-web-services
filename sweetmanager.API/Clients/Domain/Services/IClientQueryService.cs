using sweetmanager.API.Clients.Domain.Model.Queries;
using sweetmanager.API.Clients.Domain.Model.Aggregates;
namespace sweetmanager.API.Clients.Domain.Services
{
    public interface IClientQueryService
    {
        Task<IEnumerable<Client>> Handle(GetAllClientsQuery query);
        Task<Client?> Handle(GetClientByIdQuery query);
    }
}