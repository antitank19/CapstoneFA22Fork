namespace Domain.EntitiesForManagement;

public class Appartment
{
    public Appartment()
    {
        Buildings = new HashSet<Building>();
    }

    public int AppartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}