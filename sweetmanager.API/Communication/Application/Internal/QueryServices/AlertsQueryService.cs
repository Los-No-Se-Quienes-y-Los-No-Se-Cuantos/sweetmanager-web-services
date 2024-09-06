using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Domain.Model.Queries;
using sweetmanager.API.Communication.Domain.Repositories;
using sweetmanager.API.Communication.Domain.Services;

namespace sweetmanager.API.communication.Application.Internal.QueryServices;

public class AlertsQueryService(IAlertsRepository alertsRepository): IAlertsQueryService
{
    public async Task<IEnumerable<Alerts>> Handle(GetAllAlertsQuery query)
    {
        return await alertsRepository.ListAsync();
    }

    public async Task<Alerts?> Handle(GetAlertsByIdQuery query)
    {
        return await alertsRepository.FindByIdAsync(query.AlertId);
    }
}


