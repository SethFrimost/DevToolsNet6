using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DevToolsNet.GoogleServices;


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

    public async Task<string> UploadFile(string localFilePath, string mimeType)
    {
        IUploadProgress res;
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
            res = await request.UploadAsync();
            
        }

        if(request.ResponseBody == null) return null;
        else return request.ResponseBody.Id;
    }


    public async Task DownloadFile(string fileId, string destinationPath)
    {
        var request = _service.Files.Get(fileId);
        using (var stream = new FileStream(destinationPath, FileMode.Create))
        {
            await request.DownloadAsync(stream);
        }
    }

    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFiles()
    {
        var request = _service.Files.List();
        request.PageSize = 20;
        request.Fields = "nextPageToken, files(id, name, parents)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }

    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFiles(string parentFolderId)
    {
        var request = _service.Files.List();
        request.Q = $"'{parentFolderId}' in parents";
        request.PageSize = 20;
        request.Fields = "nextPageToken, files(id, name, parents, mimeType)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }

    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListRootFolders()
    {
        var request = _service.Files.List();
        request.Q = "mimeType = 'application/vnd.google-apps.folder' and 'root' in parents";
        request.Fields = "nextPageToken, files(id, name)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }
    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFoldersInFolder(string parentFolderId)
    {
        var request = _service.Files.List();
        request.Q = $"mimeType = 'application/vnd.google-apps.folder' and '{parentFolderId}' in parents";
        request.Fields = "nextPageToken, files(id, name)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }

    public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFolders()
    {
        var request = _service.Files.List();
        request.Q = "mimeType = 'application/vnd.google-apps.folder'";
        request.Fields = "nextPageToken, files(id, name, parents)";
        var result = await request.ExecuteAsync();
        return result.Files;
    }

    public async Task<string> CreateFolder(string folderName, string parentFolderId = null)
    {
        try
        {
            var fileMetaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            if (!string.IsNullOrEmpty(parentFolderId))
            {
                fileMetaData.Parents = new List<string> { parentFolderId };
            }

            var request = _service.Files.Create(fileMetaData);
            request.Fields = "id";
            var res = request.Execute();
            return res.Id;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            return null;
        }
       
    }
}