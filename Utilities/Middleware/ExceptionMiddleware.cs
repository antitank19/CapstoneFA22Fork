using System.Net;
using Domain.ErrorEntities;
using Microsoft.AspNetCore.Http;
using Utilities.HttpException;

namespace Utilities.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
        try
        {
            await _next(context);
        }
        catch (HttpStatusException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception exceptionObj)
        {
            await HandleExceptionAsync(context, exceptionObj);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, HttpStatusException exception)
    {
        string result;
        context.Response.ContentType = "application/json";
        if (exception is HttpStatusException)
        {
            result = new ErrorDetails
            {
                Message = exception.Message,
                StatusCode = exception.StatusCode
            }.ToString();
            context.Response.StatusCode = (int)exception.StatusCode;
        }
        else
        {
            result = new ErrorDetails
            {
                Message = "Runtime Error",
                StatusCode = HttpStatusCode.BadRequest
            }.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var result = new ErrorDetails
        {
            Message = exception.Message,
            StatusCode = HttpStatusCode.InternalServerError
        }.ToString();
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return context.Response.WriteAsync(result);
    }
}