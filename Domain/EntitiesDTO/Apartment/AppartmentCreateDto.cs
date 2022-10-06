using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO.Apartment;

public class ApartmentCreateDto
{
    public int ApartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public virtual ICollection<BuildingGetDto> Buildings { get; set; }
}