using ApiAggregation.Enums;
using System;
using System.Collections.Generic;

namespace ApiAggregation.Responses;

public class ResponseBaseModel<T>
{

    public ResponseBaseModel()
    {
        Errors = new();
        Timestamp = DateTime.UtcNow;
    }

    public ResponseBaseModel(T payload) : this()
    {
        Payload = payload;
    }

    public T Payload { get; set; }
    public DateTime Timestamp { get; set; }
    public List<Error> Errors { get; set; }
}

public class Error
{
    public Error() { }  
    public Error(ErrorCodes errorCode, string errorDescription, ErrorTypes errorType)
    {
        ErrorCode = errorCode.ToString();
        ErrorDescription = errorDescription;
        ErrorType = errorType;
    }

    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public ErrorTypes ErrorType { get; set; }
}
