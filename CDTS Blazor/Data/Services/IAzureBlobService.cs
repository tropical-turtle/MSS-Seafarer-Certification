using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDTS_Blazor.Data.Services
{
    public interface IAzureBlobService
    {

        Task<CloudBlockBlob> UploadFileAsync(IFormFile file, string container = null);

        Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFileListEntry[] files, string container = null);

        Task<List<CloudBlockBlob>> UploadMultipleFilesAsync(IFormFileCollection files, string container = null);

    }
}
