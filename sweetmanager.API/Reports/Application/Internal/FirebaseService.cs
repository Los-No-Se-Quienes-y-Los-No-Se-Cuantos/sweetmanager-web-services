using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Reports.Infrastructure.Persistence.EFC;

namespace sweetmanager.API.Reports.Application.Internal;

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseClient _firebaseClient;

    public FirebaseService(FirebaseClient firebaseClient)
    {
        _firebaseClient = firebaseClient;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        return await _firebaseClient.UploadFileAsync(fileStream, fileName);
    }
}