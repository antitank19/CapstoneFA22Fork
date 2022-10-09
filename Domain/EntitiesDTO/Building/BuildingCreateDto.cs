namespace Domain.EntitiesDTO;

public class BuildingCreateDto
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }

    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int? TotalFloor { get; set; }
    public int? TotalRooms { get; set; }
    public int? CoordinateX { get; set; }
    public int? CoordinateY { get; set; }
    public int Status { get; set; }
    public int AppartmentId { get; set; }
    public virtual ICollection<FlatCreateDto>? Flats { get; set; }
}