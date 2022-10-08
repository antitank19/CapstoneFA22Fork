using Domain.EntitiesDTO.Apartment;

namespace Domain.EntitiesDTO.Area;

public class AreaUpdateDto
{
    public int AreaId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public virtual ICollection<ApartmentUpdateDto>? Appartments { get; set; }
}