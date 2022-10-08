namespace Domain.EntitiesDTO;

public class ApartmentGetDto
{
    public int ApartmentId { get; set; }
    public string Name { get; set; }
    public int AreaId { get; set; }
    public AreaGetDto Area { get; set; }
    public virtual ICollection<BuildingGetDto> Buildings { get; set; }
}