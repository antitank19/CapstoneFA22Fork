namespace Domain.EntitiesDTO;

public class ServiceCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int ServiceTypeId { get; set; }
}