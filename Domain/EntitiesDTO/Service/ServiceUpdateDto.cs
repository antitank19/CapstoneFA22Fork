namespace Domain.EntitiesDTO.Service;

public class ServiceUpdateDto
{
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int ServiceTypeId { get; set; }
}