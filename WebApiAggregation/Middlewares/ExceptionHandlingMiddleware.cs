using ApiAggregation.Enums;
using ApiAggregation.Responses;
using System.Net;
using ApiAggregation.Exceptions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace ApiAggregation.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationErrorException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorType = exception.ErrorType,
                ErrorCode = exception.ErrorCode.ToString(),
                ErrorDescription = exception.Message
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        catch (BusinessErrorException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorType = exception.ErrorType,
                ErrorCode = exception.ErrorCode.ToString(),
                ErrorDescription = exception.Message
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        catch (SystemErrorException exception)
        {
            _logger.LogError($"{exception.ErrorType}: {exception.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorType = exception.ErrorType,
                ErrorCode = exception.ErrorCode.ToString(),
                ErrorDescription = exception.Message
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }
        catch (AuthErrorException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorType = exception.ErrorType,
                ErrorCode = exception.ErrorCode.ToString(),
                ErrorDescription = exception.Message
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }
        catch (ModuleNotActiveErrorException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorDescription = "Module is not activated."
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }
        catch (Exception exception)
        {
             _logger.LogError($"{exception}");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            ResponseBaseModel<Object> response = new();

            response.Errors.Add(new Error()
            {
                ErrorCode = ErrorCodes.GeneralSystemError.ToString()
            });

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}