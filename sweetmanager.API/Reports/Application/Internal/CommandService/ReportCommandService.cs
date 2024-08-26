using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Repositories;
using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Reports.Application.Internal.CommandService;

public class ReportCommandService(IReportRepository reportRepository,
IUnitOfWork unitOfWork) : IReportCommandService
{
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        try
        {
            var result = new Report(command);
            
            await reportRepository.AddAsync(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Report?> Handle(UpdateReportCommand command)
    {
        try
        {
            var result = await reportRepository.FindByIdAsync(command.Id);

            if (result == null)
                throw new Exception($"Report with id {command.Id} not found");

            result.Update(command);

            reportRepository.Update(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Report?> Handle(DeleteReportCommand command)
    {
        try
        {
            var result = await reportRepository.FindByIdAsync(command.Id);

            if (result == null)
                throw new Exception($"Report with id {command.Id} not found");

            result.Delete();

            reportRepository.Remove(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }
}