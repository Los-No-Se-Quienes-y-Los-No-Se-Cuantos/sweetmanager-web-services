using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Domain.Model.Queries;

namespace sweetmanager.API.Communication.Domain.Services;

public interface IAlertsQueryService
{
    Task<IEnumerable<Alerts>> Handle(GetAllAlertsQuery query);
    
    Task<Alerts?> Handle(GetAlertsByIdQuery query);
}