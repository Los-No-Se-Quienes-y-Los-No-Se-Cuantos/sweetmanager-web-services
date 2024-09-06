using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Queries;
using sweetmanager.API.Reports.Domain.Repositories;
using sweetmanager.API.Reports.Domain.Services;

namespace sweetmanager.API.Reports.Application.Internal.QueryService;

public class ReportQueryService (IReportRepository reportRepository): IReportQueryService
{
    public async Task<Report?> Handle(GetReportByIdQuery query)
    {
        return await reportRepository.FindByIdAsync(query.Id);
    }
}