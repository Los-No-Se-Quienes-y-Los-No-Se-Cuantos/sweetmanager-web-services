namespace sweetmanager.API.Clients.Interface.ACL
{
    public interface IClientsContextFacade
    {
        Task<int> CreateClient(int id, string name, string lastName, int age, string genre, int phone, string email, string state);
        Task<int> FetchClientById(int id);
    }
}