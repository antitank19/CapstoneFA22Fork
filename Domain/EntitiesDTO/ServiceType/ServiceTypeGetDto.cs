namespace Domain.EntitiesDTO;

public class ServiceTypeGetDto
{
    public int ServiceTypeId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public virtual ICollection<ServiceGetDto> Services { get; set; }
}