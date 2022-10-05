namespace Domain.EntitiesForManagement;

public class ServiceType
{
    public ServiceType()
    {
        ServiceEntities = new HashSet<ServiceEntity>();
    }

    public int ServiceTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ServiceEntity> ServiceEntities { get; set; }
}