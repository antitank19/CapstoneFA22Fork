using System.Runtime.Serialization;

namespace Domain.ErrorEntities;

[DataContract(Name= "ErrorResponse")]
public class ErrorResponse
{
    [DataMember(Name = "Message")]
    public string Message { get; set; }

    public ErrorResponse(string message)
    {
        Message = message;
    }
}