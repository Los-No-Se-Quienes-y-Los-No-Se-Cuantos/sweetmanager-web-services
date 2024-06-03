using sweetmanager.API.Clients.Domain.Model.Commands;
using sweetmanager.API.Clients.Domain.Model.Aggregates;

namespace sweetmanager.API.Clients.Domain.Services
{
    public interface IClientCommandService
    {
        Task<Client?> Handle(CreateClientCommand command);
    }
}