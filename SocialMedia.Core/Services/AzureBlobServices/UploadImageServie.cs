using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.ServicesInterfaces.AzureBlobInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.AzureBlobServices
{
    public class UploadImageServie : IUploadImageServie
    {
        private IConfiguration _configuration;
        private readonly string _storageConnectionString;
        private readonly string _containerName;
        public UploadImageServie(IConfiguration configuration)
        {
            _configuration = configuration;
            _storageConnectionString = _configuration["BlobAccount:AzureBlobConnectionString"];
            _containerName = _configuration["BlobAccount:AzureContainerName"];
        }
        public async Task<string> UploadImage(IFormFile image)
        {

            BlobServiceClient blobServiceClient = new BlobServiceClient(_storageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            BlobClient blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());
            using (var stream = image.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }
            return blobClient.Uri.ToString();
        }
    }
}
