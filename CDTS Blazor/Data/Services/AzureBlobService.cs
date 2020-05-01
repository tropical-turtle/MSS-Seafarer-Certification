using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CDTS_Blazor.Data.Services
{
    public class AzureBlobService : IAzureBlobService
    {

        private readonly IAzureBlobConnectionFactory _azureBlobConnectionFactory;

        public AzureBlobService(IAzureBlobConnectionFactory azureBlobConnectionFactory)
        {
            _azureBlobConnectionFactory = azureBlobConnectionFactory;
        }

        public async Task<CloudBlockBlob> UploadFileAsync(IFormFile file, string container)
        {

            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();

            var blobName = UnqiueFileName(file.FileName);

            // Create the blob to hold the data
            var blob = blobContainer.GetBlockBlobReference(blobName);
            // Send the file to the cloud storage
            using(var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream);
            }

            return blob;

        }

        private string UnqiueFileName(string currentFileName)
        {
            string ext = Path.GetExtension(currentFileName);

            string nameWithNoExt = Path.GetFileNameWithoutExtension(currentFileName);

            return string.Format("{0}_{1}{2}", nameWithNoExt, DateTime.UtcNow.Ticks, ext);
        }
    }
}
