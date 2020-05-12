using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CDNApplication.Data.Services
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
            // Perhaps we can fail more gracefully then just throwing an exception
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer().ConfigureAwait(false);

            var blobName = AzureBlobService.UnqiueFileName(file.FileName);

            // Create the blob to hold the data
            var blob = blobContainer.GetBlockBlobReference(blobName);
            // Send the file to the cloud storage
            using(var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream).ConfigureAwait(false);
            }

            return blob;
        }

        private static string UnqiueFileName(string currentFileName)
        {
            string ext = Path.GetExtension(currentFileName);

            string nameWithNoExt = Path.GetFileNameWithoutExtension(currentFileName);

            return string.Format(CultureInfo.InvariantCulture, "{0}_{1}{2}", nameWithNoExt, DateTime.UtcNow.Ticks, ext);
        }
    }
}
