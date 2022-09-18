namespace Domain.EntitiesForManagement;

public class Address
{
    public int AddressId { get; set; }
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string Ward { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
}