namespace ApiAggregation.Enums;

public enum ErrorTypes
{
    ValidationError = 1,
    BusinessError = 2,
    SystemError = 3,
    AuthenticationError = 4
}

public enum ErrorCodes
{
    HttpRequestException,
    ValidationError,
    NotFound,
    Unauthorized,
    Forbidden,
    InternalServerError,
    BadRequest,
    ServiceUnavailable,
    GeneralSystemError
}
