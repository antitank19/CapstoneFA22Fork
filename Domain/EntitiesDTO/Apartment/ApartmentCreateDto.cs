using Domain.EntitiesDTO.Building;

namespace Domain.EntitiesDTO.Apartment;

public class ApartmentCreateDto
{
    public string Name { get; set; }
    public int AreaId { get; set; }

    public virtual ICollection<BuildingCreateDto>? Buildings { get; set; }
}