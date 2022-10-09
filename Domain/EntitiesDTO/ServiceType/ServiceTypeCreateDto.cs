namespace Domain.EntitiesDTO;

public class ServiceTypeCreateDto
{
    public string Name { get; set; }
    public virtual ICollection<ServiceCreateDto> Services { get; set; }
}