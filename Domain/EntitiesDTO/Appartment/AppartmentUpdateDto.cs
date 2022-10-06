using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO;

public class AppartmentUpdateDto
{
    public int AppartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public virtual ICollection<BuildingGetDto> Buildings { get; set; }
}