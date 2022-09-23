using System.Net;
using Newtonsoft.Json;

namespace Domain.ErrorEntities;

public class ErrorDetails
{
    public HttpStatusCode StatusCode { get; set; }

    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}