namespace API.Controllers;

/*
[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("error")]
    public MyErrorResponse Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context.Error; // Your exception
        var code = 500; // Internal Server Error by default

        if      (exception is MyNotFoundException) code = 404; // Not Found
        else if (exception is MyUnauthException)   code = 401; // Unauthorized
        else if (exception is MyException)         code = 400; // Bad Request

        Response.StatusCode = code; // You can use HttpStatusCode enum instead

        return new MyErrorResponse(exception); // Your error model
    }
}
*/