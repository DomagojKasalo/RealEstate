using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace API.Controllers.AUT
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AzureController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AzureController> _logger;

        public AzureController(IConfiguration configuration, ILogger<AzureController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Invalid file");
                }

                // Get Azure Blob Storage connection string from appsettings.json
                string storageConnectionString = _configuration.GetConnectionString("AzureBlobStorage");

                // Create a CloudStorageAccount from the connection string
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

                // Create a CloudBlobClient object for interacting with Blob service
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to the container
                CloudBlobContainer container = blobClient.GetContainerReference("file-upload");

                // Create a unique name for the blob
                string blobName = $"{Guid.NewGuid()}-{file.FileName}";

                // Get a reference to the blob
                CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

                // Upload the file to Azure Blob Storage
                using (var stream = file.OpenReadStream())
                {
                    await blob.UploadFromStreamAsync(stream);
                }

                // Return the URL of the uploaded blob
                return Ok(blob.Uri.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file to Azure Blob Storage");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListFiles()
        {
            try
            {
                // Get Azure Blob Storage connection string from appsettings.json
                string storageConnectionString = _configuration.GetConnectionString("AzureBlobStorage");

                // Create a CloudStorageAccount from the connection string
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

                // Create a CloudBlobClient object for interacting with Blob service
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to the container
                CloudBlobContainer container = blobClient.GetContainerReference("file-upload");

                // List the blobs (files) in the container
                var blobs = await container.ListBlobsSegmentedAsync(null);

                var fileInfos = blobs.Results.Select(blob =>
                {
                    if (blob is CloudBlockBlob blockBlob)
                    {
                        return new
                        {
                            Name = blockBlob.Name,
                            Uri = blockBlob.Uri.ToString(),
                            IsDirectory = false
                        };
                    }
                    // You can handle directories or other types of blobs here if needed.

                    return null;
                }).Where(info => info != null).ToList();

                return Ok(fileInfos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listing files in Azure Blob Storage");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
//private readonly AzureService _azureService;

//public AzureController(AzureService azureService)
//{
//    _azureService = azureService;
//}

//[HttpGet]
//public async Task<ActionResult<FileModel[]>> ListFiles()
//{
//    var files = await _azureService.ListFilesAsync();
//    return Ok(files);
//}

//[HttpPost]
//[Route("upload")]
//public async Task<IActionResult> UploadFile(IFormFile file)
//{
//    if (file == null || file.Length == 0)
//        return BadRequest("File is empty");

//    using (var stream = file.OpenReadStream())
//    {
//        await _azureService.UploadFileAsync(stream, file.FileName);
//    }

//    return Ok();
//}

//[HttpGet("{fileName}")]
//public async Task<IActionResult> DownloadFile(string fileName)
//{
//    var stream = await _azureService.DownloadFileAsync(fileName);
//    if (stream == null)
//        return NotFound();

//    return File(stream, "application/octet-stream", fileName);
//}
