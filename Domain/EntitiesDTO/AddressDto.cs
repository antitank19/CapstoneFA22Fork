namespace Domain.EntitiesDTO;

public class AddressDto
{
    public CityDto CityDto { get; set; }
    public WardDto WardDto { get; set; }
    public DistrictDto DistrictDto { get; set; }
}