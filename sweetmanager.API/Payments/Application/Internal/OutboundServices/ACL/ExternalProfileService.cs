using sweetmanager.API.Clients.Interfaces.ACL;
using sweetmanager.API.Payments.Domain.Model.ValueObjects;

namespace sweetmanager.API.Payments.Application.Internal.OutboundServices.ACL;

public class ExternalProfileService(IClientsContextFacade clientsContextFacade)
{
    public async Task<ProfileId?> FetchProfileByEmail(string email)
    {
        var clientId = await clientsContextFacade.FetchClientByEmail(email);
        if (clientId == 0) return await Task.FromResult<ProfileId?>(null);
        return new ProfileId(clientId);
    }
}