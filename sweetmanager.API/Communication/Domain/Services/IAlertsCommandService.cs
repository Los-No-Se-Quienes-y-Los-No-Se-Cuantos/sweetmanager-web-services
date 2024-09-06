using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Domain.Model.Commands;

namespace sweetmanager.API.Communication.Domain.Services;

public interface IAlertsCommandService
{
    Task<Alerts?> Handle(CreateAlertsCommand command);
}