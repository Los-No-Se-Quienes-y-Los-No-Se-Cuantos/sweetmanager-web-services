using sweetmanager.API.Clients.Domain.Model.Aggregates;
using sweetmanager.API.Clients.Domain.Model.Queries;
using sweetmanager.API.Clients.Domain.Repositories;
using sweetmanager.API.Clients.Domain.Services;

namespace sweetmanager.API.Clients.Application.Internal.QueryServices
{
    public class ClientQueryService(IClientRepository clientRepository) : IClientQueryService
    {
        public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
        {
            return await clientRepository.ListAsync();
        }
        public async Task<Client?> Handle(GetClientByIdQuery query)
        {
            return await clientRepository.FindByIdAsync(query.Id);
        }

        public async Task<Client?> Handle(GetClientByEmailQuery query)
        {
            return await clientRepository.FindByEmailAsync(query.Email);
        }
    }
}