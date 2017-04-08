using FlexiApp.Domain.Models.GoogleDrive;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FlexiApp.Infrastructure.Helper
{
    public class GoogleDrive
    {
        static string[] Scopes = { DriveService.Scope.Drive,
                           DriveService.Scope.DriveAppdata,
                           DriveService.Scope.DriveFile,
                           DriveService.Scope.DriveMetadataReadonly,
                           DriveService.Scope.DriveReadonly,
                           DriveService.Scope.DriveScripts  };

        static string ApplicationName = "FlexiApp";
        public string UploadFile(Credentials credentials, string fileFolder, byte[] file, string fileName, string mimeType)
        {
            try
            {
                UserCredential credential;

                credential = GetCredentials(credentials);

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                var destination = GetFolderId(service, fileFolder);
                var fileMetadata = new Google.Apis.Drive.v3.Data.File();
                fileMetadata.Name = fileName;
                fileMetadata.MimeType = mimeType;
                fileMetadata.Parents = new List<string>()
                {
                   destination
                };

                FilesResource.CreateMediaUpload request;

                request = service.Files.Create(fileMetadata, new MemoryStream(file), mimeType);
                request.Fields = "id";
                request.Upload();

                var responseFile = request.ResponseBody;

                return responseFile.Id;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public MemoryStream DownloadFile(Credentials credentials, string fileFolder, string mimeType)
        {
            try
            {
                UserCredential credential;

                credential = GetCredentials(credentials);

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                var source = GetFolderId(service, fileFolder);

                var pageToken = "";
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 1;
                listRequest.Fields = "nextPageToken, files(id,name)";
                listRequest.PageToken = pageToken;
                listRequest.Q = mimeType + " and '" + source + "' in parents";

                var request = listRequest.Execute();

                if (request.Files != null && request.Files.Count > 0)
                {
                    foreach (var file in request.Files)
                    {
                        var fileId = file.Id;
                        var request1 = service.Files.Get(fileId);
                        var stream = new System.IO.MemoryStream();

                        request1.MediaDownloader.ProgressChanged +=
                            (IDownloadProgress progress) =>
                            {
                                switch (progress.Status)
                                {
                                    case DownloadStatus.Downloading:
                                        {
                                            break;
                                        }
                                    case DownloadStatus.Completed:
                                        {
                                            break;
                                        }
                                    case DownloadStatus.Failed:
                                        {
                                            break;
                                        }
                                }
                            };
                        request1.Download(stream);
                        return stream;
                    }
                }
                return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private static UserCredential GetCredentials(Credentials credentials)
        {
            UserCredential credential;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            var json = "{'installed':{'client_id':'" + credentials.ClientId + "','project_id':'" + credentials.ProjectId + "','auth_uri':'https://accounts.google.com/o/oauth2/auth','token_uri':'https://accounts.google.com/o/oauth2/token','auth_provider_x509_cert_url':'https://www.googleapis.com/oauth2/v1/certs','client_secret':'" + credentials.ClientSecret + "','redirect_uris':['urn:ietf:wg:oauth:2.0:oob','http://localhost']}}";
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None).Result;

            return credential;
        }

        public string GetFolderId(DriveService driveService, string folderName)
        {
            FilesResource.ListRequest listRequest = driveService.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id,name)";
            listRequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name contains '" + folderName + "'";
            var request = listRequest.Execute();

            if (request.Files != null && request.Files.Count > 0)
            {
                return request.Files[0].Id;
            }
            return "";
        }
    }
}
