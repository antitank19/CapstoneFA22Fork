using Domain.EntitiesDTO.Service;

namespace Domain.EntitiesDTO.ServiceType;

public class ServiceTypeGetDto
{
    public int ServiceTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ServiceGetDto> Services { get; set; }
}