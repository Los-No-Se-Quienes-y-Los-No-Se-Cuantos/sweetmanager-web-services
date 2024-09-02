namespace sweetmanager.API.Reports.Domain.Services;

public interface IFirebaseService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName);
}