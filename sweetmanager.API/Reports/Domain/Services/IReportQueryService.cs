using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Queries;

namespace sweetmanager.API.Reports.Domain.Services;

public interface IReportQueryService
{
    Task<Report?> Handle(GetReportByIdQuery query);

}