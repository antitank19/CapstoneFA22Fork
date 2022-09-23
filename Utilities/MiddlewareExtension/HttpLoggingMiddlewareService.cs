using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Utilities.MiddlewareExtension;

public class HttpLoggingMiddlewareService
{
    /// <summary>
    /// Middleware for Logging Request and Responses.
    /// Remarks: Original code taken from https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
    /// </summary>
    
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public HttpLoggingMiddlewareService(RequestDelegate next, ILogger<HttpLoggingMiddlewareService> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //Copy  pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            //Get incoming request
            var request = await GetRequestAsTextAsync(context.Request);
            //Log it
            _logger.LogInformation("${Request}", request);


            //Create a new memory stream and use it for the temp reponse body
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            //Continue down the Middleware pipeline
            await _next(context);

            //Format the response from the server
            var response = await GetResponseAsTextAsync(context.Response);
            //Log it
            _logger.LogInformation("${Response}", response);

            //Copy the contents of the new memory stream, which contains the response to the original stream, which is then returned to the client.
            await responseBody.CopyToAsync(originalBodyStream);
        }

        
        private static async Task<string> GetRequestAsTextAsync(HttpRequest request)
        {
            var body = request.Body;

            //Set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            // Convert request content to string value to avoid boxing from long to object
            var requestContent = request.ContentLength is > 0 ? 
                await new StreamReader(request.Body).ReadToEndAsync() : string.Empty;

            //Convert to byteArray 
            var byteArray = Convert.ToInt32(requestContent);
            
            //Read request stream
            var buffer = new byte[byteArray];

            //Copy into buffer.
            var readAsync = await request.Body.ReadAsync(buffer);

            //Convert the byte[] into a string using UTF8 encoding...
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            //Assign the read body back to the request body
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
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