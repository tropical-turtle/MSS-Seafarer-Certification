using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;

namespace CDNApplication.Data.Services
{
    public interface IAzureBlobService
    {

        Task<CloudBlockBlob> UploadFileAsync(IFormFile file, string container = null);

        Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFileListEntry[] files, string container = null);

        Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFormFileCollection files, string container = null);

    }
}
