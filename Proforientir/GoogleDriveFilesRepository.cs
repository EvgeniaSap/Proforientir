using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Download;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Web;

namespace Proforientir
{
    class GoogleDriveFilesRepository
    {
        //defined scope.
        public static string[] Scopes = { DriveService.Scope.Drive };
        public static string ApplicationName = "Proforientir";

        //create Drive API service.
        /*  public static DriveService GetService()
          {
              //get Credentials from client_secret.json file 
              UserCredential credential;
              using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
              {
                  String FolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                  String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");

                  credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                      GoogleClientSecrets.Load(stream).Secrets,
                      Scopes,
                      "user",
                      CancellationToken.None,
                      new FileDataStore(FilePath, true)).Result;
              }

              //create Drive API service.
              DriveService service = new DriveService(new BaseClientService.Initializer()
              {
                  HttpClientInitializer = credential,
                  ApplicationName = "Proforientir",
              });
              return service;
          }*/

        public static DriveService GetService()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                //string credPath = "token.json";
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            }); ;
            
            return service;
        }

        //get all files from Google Drive.
        public static List<GoogleDriveFiles> GetDriveFiles()
        {
            DriveService service = GetService();

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            //get file list. все файлы
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFiles File = new GoogleDriveFiles
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }

       /* //file Upload to the Google Drive.
        public static void FileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                DriveService service = GetService();

                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);

                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.FileName);
                FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);

                FilesResource.CreateMediaUpload request;

                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
            }
        }

      /*  //Download file from Google Drive by fileId.
        public static string DownloadGoogleFile(string fileId)
        {
            DriveService service = GetService();

           // string FolderPath = System.Web.HttpContext.Current.Server.MapPath("/GoogleDriveFiles/"); //создать папку, куда сохранять
            FilesResource.GetRequest request = service.Files.Get(fileId);

            string FileName = request.Execute().Name;
          //  string FilePath = System.IO.Path.Combine(FolderPath, FileName);

            MemoryStream stream1 = new MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            //long str = progress.BytesDownloaded;
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                             Console.WriteLine("Download complete.");
                            SaveStream(stream1, FileName);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream1);

            

            return FileName;
        }

        // file save to server path
        public static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }*/

        //Delete file from the Google drive
        public static void DeleteFile(string filesID)
        {
            DriveService service = GetService();
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                if (filesID == null)
                    throw new ArgumentNullException(filesID);

                // Make the request.
                service.Files.Delete(filesID).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Files.Delete failed.", ex);
            }
        }
    }
}
