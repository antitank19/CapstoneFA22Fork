namespace Domain.EntitiesDTO;

public class FlatCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int FlatTypeId { get; set; }
    public int BuildingId { get; set; }
}