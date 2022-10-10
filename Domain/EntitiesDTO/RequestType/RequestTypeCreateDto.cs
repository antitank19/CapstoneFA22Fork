namespace Domain.EntitiesDTO;

public class RequestTypeCreateDto
{
    public int RequestTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}