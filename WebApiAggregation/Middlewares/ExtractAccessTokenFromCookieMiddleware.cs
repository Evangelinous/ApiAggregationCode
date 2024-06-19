using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApiAggregation.Middlewares;

/// <summary>
/// This middleware extracts the AccessToken from Http-Only Cookie (X-Access-Token) and adds it to the Authorization header to be forwarded to the Microservices calls
/// </summary>
public class ExtractAccessTokenFromCookieMiddleware
{
    private readonly RequestDelegate _next;

    public ExtractAccessTokenFromCookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var authenticationCookieName = "X-Access-Token";
        var cookie = context.Request.Cookies[authenticationCookieName];
        if (cookie != null)
        {
            var token = cookie;
            context.Request.Headers.Append("Authorization", "Bearer " + token);
        }

        await _next.Invoke(context);
    }
}

