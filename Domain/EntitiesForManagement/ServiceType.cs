namespace Domain.EntitiesForManagement
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}