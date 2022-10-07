using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO;

public class ApartmentCreateDto
{
    public string Name { get; set; }
    public int AreaId { get; set; }

    public virtual ICollection<BuildingCreateDto>? Buildings { get; set; }
}