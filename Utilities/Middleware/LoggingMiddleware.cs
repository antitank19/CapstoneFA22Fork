using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;

namespace Utilities.Middleware;

public class LoggingMiddleware
{
    private const int ReadChunkBufferLength = 4096;
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<LoggingMiddleware>();
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // var requestData = GetRequestData(context);
        // var requestDisplayUrl = context.Request.GetDisplayUrl();
        try
        {
            await LogRequest(context.Request);
            await LogResponseAsync(context);
            await _next(context);
        }
        catch (Exception ex)
        {
            /*
                        var routeData = context.GetRouteData();
            
                        // TODO: implement logging to files here, adding 3rd party logger here ^^
                        _logger.LogError(ex,
                            "An unhandled exception has occurred while executing the request. " +
                            "\nUrl: {RequestDisplayUrl}. " +
                            "\nRequest Data: {RequestData}", requestDisplayUrl, requestData);
            
                        var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);
            
                        var result = new ObjectResult(
                            new ErrorResponse(
                                "Error processing request. Server error."))
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError
                        };
                        
                        //ClearCacheHeaders(context.Response);
            
                        await _executor.ExecuteAsync(actionContext, result);
                        */
        }
    }


    private static void ClearCacheHeaders(HttpResponse response)
    {
        response.Headers[HeaderNames.CacheControl] = "no-cache";
        response.Headers[HeaderNames.Pragma] = "no-cache";
        response.Headers[HeaderNames.Expires] = "-1";
        response.Headers.Remove(HeaderNames.ETag);
    }

    private async Task LogRequest(HttpRequest request)
    {
        request.EnableBuffering();
        await using var requestStream = _recyclableMemoryStreamManager.GetStream();
        await request.Body.CopyToAsync(requestStream);
        request.Body.Position = 0;

        var queryStringNullOrNot = request.QueryString.HasValue ? request.QueryString.Value : "No query string";

        var readStreamInChunks = await ReadStreamInChunks(requestStream);

        _logger.LogInformation("\nHttp Request Information:" +
                               "\nSchema:{request.Scheme} " +
                               "\nHost: {request.Host} " +
                               "\nPath: {request.Path} " +
                               "\nQueryString: {request.QueryString} " +
                               "\nRequest Body: {ReadStreamInChunks} \n"
            , request.Scheme, request.Host,
            request.Path, queryStringNullOrNot, readStreamInChunks);
    }

    private async Task LogResponseAsync(HttpContext context)
    {
        var originalBody = context.Response.Body;
        await using var responseStream = _recyclableMemoryStreamManager.GetStream();
        context.Response.Body = responseStream;
        await responseStream.CopyToAsync(originalBody);

        var readStreamInChunks = await ReadStreamInChunks(responseStream);

        var queryStringNullOrNot = context.Request.QueryString.HasValue
            ? context.Request.QueryString.Value
            : "No query string";

        _logger.LogInformation("\nHttp Response Information\n" +
                               "\nSchema:{context.Request.Scheme} " +
                               "\nHost: {context.Request.Host} " +
                               "\nPath: {context.Request.Path} " +
                               "\nQueryString: {context.Request.QueryString} " +
                               "\nResponse Body: {ReadStreamInChunks} \n",
            context.Request.Scheme, context.Request.Host,
            context.Request.Path, queryStringNullOrNot, readStreamInChunks);

        context.Response.Body = originalBody;
        await _next.Invoke(context);
    }


    private static async Task<string> ReadStreamInChunks(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        await using var textWriter = new StringWriter();
        using var reader = new StreamReader(stream);
        var readChunk = new char[ReadChunkBufferLength];
        int readChunkLength;
        //do while: is useful for the last iteration in case readChunkLength < chunkLength
        do
        {
            readChunkLength = await reader.ReadBlockAsync(readChunk, 0, ReadChunkBufferLength);
            await textWriter.WriteAsync(readChunk, 0, readChunkLength);
        } while (readChunkLength > 0);

        var result = textWriter.ToString();

        return result;
    }
}