namespace Domain.EntitiesDTO;

public class RequestTypeGetDto
{
    public int RequestTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<RequestGetDto> Requests { get; set; }
}