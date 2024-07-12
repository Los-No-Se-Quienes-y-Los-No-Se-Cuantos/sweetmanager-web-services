using sweetmanager.API.Clients.Domain.Model.Commands;
using sweetmanager.API.Clients.Interfaces.REST.Resources;

namespace sweetmanager.API.Clients.Interfaces.REST.Transform
{
    public static class CreateClientCommandFromResourceAssembler
    {
        public static CreateClientCommand ToCommandFromResource(CreateClientResource resource)
        {
            return new CreateClientCommand(resource.Name, resource.LastName, resource.Age, resource.Genre,
                resource.Phone, resource.Email, resource.State);
        }
    }
}