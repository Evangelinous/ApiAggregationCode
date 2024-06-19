using ApiAggregation.Enums;
using System;
using System.Collections.Generic;

namespace ApiAggregation.Exceptions
{
    public class BaseException : Exception
    {
        public ErrorTypes ErrorType { get; set; }
        public ErrorCodes ErrorCode { get; set; }

        public BaseException(ErrorTypes errorType, ErrorCodes errorCode, string? message) : base(message)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
        }

        public BaseException(ErrorTypes errorType, ErrorCodes errorCode) : base()
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
        }

        public BaseException()
        {

        }
    }

    public class BusinessErrorException : BaseException
    {
        public BusinessErrorException(ErrorCodes errorCode, string? message) : base(ErrorTypes.BusinessError, errorCode, message) { }
        public BusinessErrorException(ErrorCodes errorCodes) : base(ErrorTypes.BusinessError, errorCodes) { }
    }

    public class SystemErrorException : BaseException
    {
        public SystemErrorException(ErrorCodes errorCode, string? message) : base(ErrorTypes.SystemError, errorCode, message) { }
        public SystemErrorException(ErrorCodes errorCodes) : base(ErrorTypes.SystemError, errorCodes) { }
    }

    public class ValidationErrorException : BaseException
    {
        public ValidationErrorException(ErrorCodes errorCode, string? message) : base(ErrorTypes.ValidationError, errorCode, message) { }
        public ValidationErrorException(ErrorCodes errorCodes) : base(ErrorTypes.ValidationError, errorCodes) { }
    }

    public class AuthErrorException : BaseException
    {
        public AuthErrorException(ErrorCodes errorCode, string? message) : base(ErrorTypes.AuthenticationError, errorCode, message) { }
        public AuthErrorException(ErrorCodes errorCodes) : base(ErrorTypes.AuthenticationError, errorCodes) { }
    }

    public class ModuleNotActiveErrorException : BaseException
    {
        public ModuleNotActiveErrorException() : base() { }
    }

    public class FilesUploadException : Exception
    {
        public string FileName { get; set; }
        public Exception Exception { get; set; }

        public FilesUploadException(Exception Exception, string FileName)
        {
            this.FileName = FileName;
            this.Exception = Exception;
        }
    }

    public class FilesDeletionException<T> : Exception
    {
        public List<T> AppFiles { get; set; }
        public Exception Exception { get; set; }

        public FilesDeletionException(Exception Exception, List<T> AppFiles)
        {
            this.AppFiles = AppFiles;
            this.Exception = Exception;
        }
    }
}
