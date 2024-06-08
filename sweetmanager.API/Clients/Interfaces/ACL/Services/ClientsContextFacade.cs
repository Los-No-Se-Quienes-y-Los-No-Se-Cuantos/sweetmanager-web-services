using sweetmanager.API.Clients.Domain.Services;

namespace sweetmanager.API.Clients.Interfaces.ACL.Services;

public class ClientsContextFacade(IClientCommandService commandService, IClientQueryService queryService): IClientsContextFacade
{
    public Task<int> CreateClient(int id, string name, string lastName, int age, string genre, int phone, string email, string state)
    {
        throw new NotImplementedException();
    }

    public Task<int> FetchClientById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> FetchClientByEmail(string email)
    {
        throw new NotImplementedException();
    }
}