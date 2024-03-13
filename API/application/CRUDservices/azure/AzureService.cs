//using Azure;
//using Azure.Storage.Blobs;
//using Azure.Storage.Blobs.Models;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//namespace application.CRUDservices.azure
//{
//    public class AzureService
//    {
//        private readonly BlobServiceClient _blobServiceClient;
//        private readonly string _containerName;

//        public AzureService(IConfiguration configuration)
//        {
//            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
//            _blobServiceClient = new BlobServiceClient(connectionString);
//            _containerName = "file-upload"; // Replace with your container name
//        }

//        public async Task UploadFileAsync(Stream stream, string fileName)
//        {
//            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
//            var blobClient = containerClient.GetBlobClient(fileName);

//            await blobClient.UploadAsync(stream, true);
//        }

//        public async Task<Stream> DownloadFileAsync(string fileName)
//        {
//            try
//            {
//                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
//                var blobClient = containerClient.GetBlobClient(fileName);

//                var response = await blobClient.OpenReadAsync();
//                var stream = response.Value.Content;

//                return stream;
//            }
//            catch (RequestFailedException ex) when (ex.Status == 404)
//            {
//                // Handle 404 (file not found) error as needed
//                // You can return a specific error message or NotFound result
//                return null; // For example, return null in case the file doesn't exist
//            }
//            catch (Exception ex)
//            {
//                // Handle other exceptions as needed
//                return null; // For example, return null for other errors
//            }
//        }

//        public async Task<FileModel[]> ListFilesAsync()
//        {
//            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
//            var files = containerClient.GetBlobsAsync();

//            List<FileModel> fileModels = new List<FileModel>();

//            await foreach (BlobItem blobItem in files)
//            {
//                fileModels.Add(new FileModel
//                {
//                    FileName = blobItem.Name,
//                    FileUri = containerClient.GetBlobClient(blobItem.Name).Uri
//                });
//            }

//            return fileModels.ToArray();
//        }

//    }
//}
