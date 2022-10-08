using Domain.EntitiesDTO.Service;

namespace Domain.EntitiesDTO.ServiceType;

internal class ServiceTypeCreate
{
    public string Name { get; set; }
    public virtual ICollection<ServiceCreateDto> Services { get; set; }
}