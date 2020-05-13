using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        public async Task<CloudBlockBlob> UploadFileAsync(IFormFile file, string container = null)
        {

            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(container);

            var blobName = UniqueFileName(file.FileName);

            // Create the blob to hold the data
            var blob = blobContainer.GetBlockBlobReference(blobName);
            // Send the file to the cloud storage
            using (var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream);
            }

            return blob;

        }

        public async Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFileListEntry[] files, string container = null)
        {

            // Get the container
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(container);

            var list = new List<CloudBlockBlob>();

            for (int i = 0; i < files.Count(); i++)
            {
                // Create the blob to hold the data
                var blob = blobContainer.GetBlockBlobReference(UniqueFileName(files[i].Name));
                // Send the file to the cloud
                using (StreamContent streamContent = new StreamContent(files[i].Data))
                {

                    var stream = await streamContent.ReadAsStreamAsync();

                    await blob.UploadFromStreamAsync(stream);

                }

                list.Add(blob);

            }

            return list;
        }

        public async Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFormFileCollection files, string container = null)

        {

            // Get the container
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer(container);

            var list = new List<CloudBlockBlob>();

            for (int i = 0; i < files.Count; i++)
            {
                // Create the blob to hold the data
                var blob = blobContainer.GetBlockBlobReference(UniqueFileName(files[i].FileName));
                // Send the file to the cloud
                using (var stream = files[i].OpenReadStream())
                {

                    await blob.UploadFromStreamAsync(stream);

                }

                list.Add(blob);

            }

            return list;
        }

        private string UniqueFileName(string currentFileName)
        {
            string ext = Path.GetExtension(currentFileName);

            string nameWithNoExt = Path.GetFileNameWithoutExtension(currentFileName);

            return string.Format("{0}_{1}{2}", nameWithNoExt, DateTime.UtcNow.Ticks, ext);
        }
    }
}
