using Domain.EntitiesDTO.RequestType;

namespace Domain.EntitiesDTO.Request;

public class RequestGetDto
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime SolveDate { get; set; }
    public int RequestTypeId { get; set; }
    public virtual RequestTypeGetDto RequestType { get; set; }
}