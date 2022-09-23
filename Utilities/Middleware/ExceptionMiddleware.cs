using System.Net;
using System.Text;
using Domain.ErrorEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Utilities.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IActionResultExecutor<ObjectResult> _executor;
    private readonly ILogger _logger;
    private static readonly ActionDescriptor EmptyActionDescriptor = new();

    public ExceptionMiddleware(RequestDelegate next, ILogger logger, IActionResultExecutor<ObjectResult> executor)
    {
        _next = next;
        _logger = logger;
        _executor = executor;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var requestData = GetRequestData(context);
            var requestDisplayUrl = context.Request.GetDisplayUrl();
            _logger.LogError(ex, 
                "An unhandled exception has occurred while executing the request. Url: {RequestDisplayUrl}. Request Data: {RequestData}",requestDisplayUrl, requestData);
            
            var routeData = context.GetRouteData();

            ClearCacheHeaders(context.Response);

            var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

            var result = new ObjectResult(new ErrorResponse("Error processing request. Server error."))
            {
                StatusCode = (int) HttpStatusCode.InternalServerError,
            };

            await _executor.ExecuteAsync(actionContext, result);        }
    }
    
    private static string GetRequestData(HttpContext context)
    {
        var sb = new StringBuilder();

        if (context.Request.HasFormContentType && context.Request.Form.Any())
        {
            sb.Append("Form variables:");
            foreach (var x in context.Request.Form)
            {
                sb.Append($"Key={x.Key}, Value={x.Value}<br/>");
            }
        }

        sb.AppendLine("Method: " + context.Request.Method);

        return sb.ToString();
    }
    
    private static void ClearCacheHeaders(HttpResponse response)
    {
        response.Headers[HeaderNames.CacheControl] = "no-cache";
        response.Headers[HeaderNames.Pragma] = "no-cache";
        response.Headers[HeaderNames.Expires] = "-1";
        response.Headers.Remove(HeaderNames.ETag);
    }
}