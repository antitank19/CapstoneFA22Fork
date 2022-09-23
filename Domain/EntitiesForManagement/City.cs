namespace Domain.EntitiesForManagement;

public class City
{
    public City()
    {
        Districts = new HashSet<District>();
    }

    public int CityId { get; set; }
    public string CityName { get; set; }
    public virtual ICollection<District> Districts { get; set; }
}