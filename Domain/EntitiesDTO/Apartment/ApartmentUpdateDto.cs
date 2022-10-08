namespace Domain.EntitiesDTO;

public class ApartmentUpdateDto
{
    public int ApartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public virtual ICollection<BuildingGetDto>? Buildings { get; set; }
}