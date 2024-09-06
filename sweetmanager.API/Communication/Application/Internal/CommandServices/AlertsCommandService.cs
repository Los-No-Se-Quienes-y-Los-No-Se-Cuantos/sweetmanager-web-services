using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Domain.Model.Commands;
using sweetmanager.API.Communication.Domain.Repositories;
using sweetmanager.API.Communication.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Communication.Application.Internal.CommandServices;

public class AlertsCommandService(IAlertsRepository alertsRepository, IUnitOfWork unitOfWork) : IAlertsCommandService
{
    public async Task<Alerts?> Handle(CreateAlertsCommand command)
    {
        var alerts = new Alerts(command);
        
        await alertsRepository.AddAsync(alerts);
        
        await unitOfWork.CompleteAsync();
        
        return alerts;
    }
}