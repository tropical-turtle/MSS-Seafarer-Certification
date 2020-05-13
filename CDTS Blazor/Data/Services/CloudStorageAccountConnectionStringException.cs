using System;
using CDNApplication.Data.Resources;
    
namespace CDNApplication.Data.Services
{
    public class CloudStorageAccountConnectionStringException : Exception
    {
        private static readonly string errorMessage = ErrorMessages.CloudStorageAccountConnectionStringExceptionErrorMessage;

        public CloudStorageAccountConnectionStringException() : base(errorMessage)
        {

        }

        public CloudStorageAccountConnectionStringException(Exception innerException)
            : base(errorMessage, innerException)
        {

        }

        public CloudStorageAccountConnectionStringException(string message) : base(message)
        {
        }

        public CloudStorageAccountConnectionStringException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}