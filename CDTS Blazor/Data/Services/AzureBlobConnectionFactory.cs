using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDTS_Blazor.Data.Services
{
    public class AzureBlobConnectionFactory : IAzureBlobConnectionFactory
    {

        private string _connectionString;

        private CloudBlobClient _cloudBlobClient;

        private CloudBlobContainer _cloudBlobContainer;

        public AzureBlobConnectionFactory()
        {
            _connectionString = Environment.GetEnvironmentVariable("BlobStorage");
        }

        public async Task<CloudBlobContainer> GetBlobContainer(string container = null)
        {

            var blobClient = GetClient();

            if (!string.IsNullOrWhiteSpace(container))
            {
                _cloudBlobContainer = blobClient.GetContainerReference(container);
            }
            else
            {
                _cloudBlobContainer = blobClient.GetRootContainerReference();
            }

            if (await _cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await _cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            return _cloudBlobContainer;
        }

        private CloudBlobClient GetClient()
        {
            if (!CloudStorageAccount.TryParse(connectionString: _connectionString, out CloudStorageAccount cloudStorageAccount))
            {
                throw new Exception("Wrong connection string");
            }

            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            return _cloudBlobClient;

        }
    }
}
