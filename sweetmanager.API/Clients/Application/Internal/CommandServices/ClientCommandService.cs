using sweetmanager.API.Clients.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Clients.Domain.Model.Commands;
using sweetmanager.API.Clients.Domain.Repositories;
using sweetmanager.API.Clients.Domain.Services;

namespace sweetmanager.API.Clients.Application.Internal.CommandServices
{
    public class ClientCommandService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        : IClientCommandService
    {
        public async Task<Client?> Handle(CreateClientCommand command)
        {
            Client clientData = new(command);

            try
            {
                await clientRepository.AddAsync(clientData);
                
                await unitOfWork.CompleteAsync();

                return clientData;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
