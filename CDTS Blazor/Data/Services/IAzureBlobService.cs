using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDNApplication.Data.Services
{
    public interface IAzureBlobService
    {

        Task<CloudBlockBlob> UploadFileAsync(IFormFile file, string container);

    }
}
