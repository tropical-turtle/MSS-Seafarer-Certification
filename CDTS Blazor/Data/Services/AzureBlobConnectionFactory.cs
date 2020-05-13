using System;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace CDNApplication.Data.Services
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

            if (await _cloudBlobContainer.CreateIfNotExistsAsync().ConfigureAwait(false))
            {
                await _cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                }).ConfigureAwait(false); ;
            }

            return _cloudBlobContainer;
        }

        private CloudBlobClient GetClient()
        {
            if (!CloudStorageAccount.TryParse(connectionString: _connectionString, out CloudStorageAccount cloudStorageAccount))
            {
                throw new CloudStorageAccountConnectionStringException();
            }

            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            return _cloudBlobClient;

        }
    }
}
