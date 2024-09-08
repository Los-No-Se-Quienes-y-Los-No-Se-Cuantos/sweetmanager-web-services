using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Model.Exceptions;
using sweetmanager.API.Reports.Domain.Model.ValueObjects;
using sweetmanager.API.Reports.Domain.Repositories;
using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Reports.Infrastructure.Persistence.EFC;
using sweetmanager.API.Reports.Infrastructure.Persistence.EFC.Requests;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Reports.Application.Internal.CommandService;

public class ReportCommandService(IReportRepository reportRepository,
IUnitOfWork unitOfWork,
IFirebaseService firebaseService) : IReportCommandService
{
  
    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        return await firebaseService.UploadFileAsync(fileStream, fileName);
    }
    
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        try
        {
            var result = new Report(command);
            
            if (string.IsNullOrEmpty(command.Title))
                throw new InvalidReportException("Title cannot be empty.");
            
            if (string.IsNullOrEmpty(command.Content))
                throw new InvalidReportException("Content cannot be empty.");
            
            if (!Enum.IsDefined(typeof(EReportType), command.ReportType))
                throw new InvalidReportException("Invalid ReportType.");

            
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
            
            if (string.IsNullOrEmpty(command.Title))
                throw new InvalidReportException("Title cannot be empty.");
            
            if (string.IsNullOrEmpty(command.Content))
                throw new InvalidReportException("Content cannot be empty.");
            
            if (!Enum.IsDefined(typeof(EReportType), command.ReportType))
                throw new InvalidReportException("Invalid ReportType.");


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