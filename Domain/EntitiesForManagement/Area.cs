namespace Domain.EntitiesForManagement;

public class Area
{
    public int AreaId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Apartment> Appartments { get; set; }
}