namespace Domain.EntitiesDTO;

public class RequestTypeUpdateDto
{
    public int RequestTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}