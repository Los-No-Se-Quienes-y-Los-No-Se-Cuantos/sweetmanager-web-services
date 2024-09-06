using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Commands;

namespace sweetmanager.API.Reports.Domain.Services;

public interface IReportCommandService
{
    Task<Report?> Handle(CreateReportCommand command);
    
    Task<Report?> Handle(UpdateReportCommand command);
    
    Task<Report?> Handle(DeleteReportCommand command);
}