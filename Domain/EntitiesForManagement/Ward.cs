namespace Domain.EntitiesForManagement;

public class Ward
{
    public Ward()
    {
        Buildings = new HashSet<Building>();
    }

    public int WardId { get; set; }
    public string WardName { get; set; }
    public int DistrictId { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}