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
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace Utilities.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IActionResultExecutor<ObjectResult> _executor;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private static readonly ActionDescriptor EmptyActionDescriptor = new();

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IActionResultExecutor<ObjectResult> executor)
    {
        _next = next;
        _logger = logger;
        _executor = executor;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestData = GetRequestData(context);
        var requestDisplayUrl = context.Request.GetDisplayUrl();
        try
        {
            //Copy pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            //Get incoming request
            var request = await GetRequestAsTextAsync(context.Request);
            
            //Create a new memory stream and use it for the temp response body
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            
            await _next(context);
            var response = await GetResponseAsTextAsync(context.Response);
            _logger.LogInformation("Request url: {RequestDisplayUrl}." +
                                   "\nRequest data: {RequestData}." +
                                   "\nRequest : {Request}." +
                                   "\nResponse : {Response}",requestDisplayUrl, requestData, request, response);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        catch (Exception ex)
        {
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
    
    private static async Task<string> GetRequestAsTextAsync(HttpRequest request)
    {
        var body = request.Body;

        //Set the reader for the request back at the beginning of its stream.
        request.EnableBuffering();

        // Convert request content to string value to avoid boxing from long to object
        var requestContent = request.ContentLength is > 0
            ? await new StreamReader(request.Body).ReadToEndAsync()
            : string.Empty;

        if (requestContent.IsNullOrEmpty()) 
            return "No request body is found";

        //Convert to byteArray 
        var byteArray = Convert.ToInt32(requestContent);

        //Read request stream
        var buffer = new byte[byteArray];

        //Copy into buffer.
        await request.Body.ReadAsync(buffer, 0, buffer.Length);

        //Convert the byte[] into a string using UTF8 encoding...
        var bodyAsText = Encoding.UTF8.GetString(buffer);

        //Assign the read body back to the request body
        request.Body = body;

        return $"Request Scheme : {request.Scheme}," +
               $"\nRequest Host : {request.Host}," +
               $"\nRequest Path : {request.Path}," +
               $"\nRequest Query String {request.QueryString}," +
               $"\nRequest Body : {bodyAsText}";
    }

    private async Task<string> GetResponseAsTextAsync(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        //Create stream reader to write entire stream
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return text;
    }
}