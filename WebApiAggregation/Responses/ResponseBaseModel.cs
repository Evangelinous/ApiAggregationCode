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
    public Error(string errorDescription)
    {
        ErrorDescription = errorDescription;
    }

    public string ErrorDescription { get; set; }
}
