namespace Domain.EntitiesDTO;

public class BuildingGetDto
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }

    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int? TotalFloor { get; set; }
    public int? TotalRooms { get; set; }
    public int? CoordinateX { get; set; }
    public int? CoordinateY { get; set; }
    public bool Status { get; set; }
    public int ApartmentId { get; set; }
    public virtual ApartmentGetDto Apartment { get; set; }
    public virtual ICollection<FlatGetDto> Flats { get; set; }
}