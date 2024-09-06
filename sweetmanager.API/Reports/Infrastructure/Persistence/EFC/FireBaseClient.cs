using Firebase.Auth;
using Firebase.Storage;

namespace sweetmanager.API.Reports.Infrastructure.Persistence.EFC;

public class FirebaseClient
{
    readonly string email = "losnosequeylosnosecomo@gmail.com";
    readonly string password = "codigo123";
    readonly string path = "imagesfirebase-38e3b.appspot.com";
    readonly string apiKey = "AIzaSyC1X7tTKHyeZsZtM8Mv5IUryUs18KHNQQM";
    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

        var cancellation = new CancellationTokenSource();

        var task = new FirebaseStorage(path, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken),
                ThrowOnCancel = true
            })
            .Child("path")
            .Child(fileName)
            .PutAsync(fileStream, cancellation.Token);

        return await task;
    }

} 