namespace Domain.EntitiesForManagement;

public class District
{
    public District()
    {
        Wards = new HashSet<Ward>();
    }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int CityId { get; set; }
    public virtual ICollection<Ward> Wards { get; set; }
}