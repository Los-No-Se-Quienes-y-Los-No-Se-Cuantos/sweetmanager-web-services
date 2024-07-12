using sweetmanager.API.Clients.Domain.Model.Commands;

namespace sweetmanager.API.Clients.Interfaces.ACL
{
    public interface IClientsContextFacade
    {
        Task<int> CreateClient(CreateClientCommand command);
        
        Task<int> FetchClientById(int id);
        
        Task<int> FetchClientByEmail(string email);
    }
}