using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class ReportRepository(AppDbContext context) : BaseRepository<Report>(context), IReportRepository
{
    
}
