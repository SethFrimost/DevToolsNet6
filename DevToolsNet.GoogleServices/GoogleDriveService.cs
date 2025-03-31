using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


// Añade los siguientes espacios de nombres
public class GoogleDriveService
{
    private DriveService _service;

    public GoogleDriveService()
    {
        Initialize().Wait();
    }

    private async Task Initialize()
    {
        UserCredential credential;

        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            string credPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "token.json");
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true));
        }

        // Crear el servicio de Google Drive
        _service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Google Drive API - MAUI App",
        });
    }

    // Método para subir archivos
    public async Task<string> UploadFile(string localFilePath, string mimeType)
    {
        var fileMetaData = new Google.Apis.Drive.v3.Data.File()
        {
            Name = Path.GetFileName(localFilePath)
        };

        FilesResource.CreateMediaUpload request;
        using (var stream = new FileStream(localFilePath, FileMode.Open))
        {
            request = _service.Files.Create(
                fileMetaData, stream, mimeType);
            request.Fields = "id";
            await request.UploadAsync();
        }
        return request.ResponseBody.Id;
    }

    // Método para descargar archivos
    public async Task DownloadFile(string fileId, string destinationPath)
    {
        var request = _service.Files.Get(fileId);
        using (var stream = new FileStream(destinationPath, FileMode.Create))
        {
            await request.DownloadAsync(stream);
        }
    }

    // Método para listar archivos
    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFiles()
    {
        var request = _service.Files.List();
        request.PageSize = 10;
        request.Fields = "nextPageToken, files(id, name)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }
}