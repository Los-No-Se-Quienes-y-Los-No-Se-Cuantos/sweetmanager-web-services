using MySqlX.XDevAPI;
using sweetmanager.API.Clients.Interfaces.REST.Resources;
using Client = sweetmanager.API.Clients.Domain.Model.Aggregates.Client;

namespace sweetmanager.API.Clients.Interfaces.REST.Transform;

public class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client client)
    {
        return new ClientResource(client.Id, client.Name, client.LastName, client.Age, client.Genre, client.Email,
            client.State);
    }
}