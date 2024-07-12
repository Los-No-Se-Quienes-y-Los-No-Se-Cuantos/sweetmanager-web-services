using sweetmanager.API.Clients.Domain.Model.Aggregates;
using sweetmanager.API.Clients.Domain.Model.Commands;
using sweetmanager.API.Clients.Domain.Model.Queries;
using sweetmanager.API.Clients.Domain.Services;

namespace sweetmanager.API.Clients.Interfaces.ACL.Services;

public class ClientsContextFacade(IClientCommandService commandService, IClientQueryService queryService): IClientsContextFacade
{
    public async Task<int> CreateClient(CreateClientCommand command)
    {
        var client = await commandService.Handle(command);

        return client?.Id ?? 0;
    }

    public async Task<int> FetchClientById(int id)
    {
        var client = await queryService.Handle(new GetClientByIdQuery(id));
        
       return client?.Id ?? 0;
    }

    public async Task<int> FetchClientByEmail(string email)
    {
        var client = await queryService.Handle(new GetClientByEmailQuery(email));

        return client?.Id ?? 0;
    }
}