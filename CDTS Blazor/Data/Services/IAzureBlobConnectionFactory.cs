using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace CDNApplication.Data.Services
{
    public interface IAzureBlobConnectionFactory
    {

        Task<CloudBlobContainer> GetBlobContainer(string container = null);

    }
}
