namespace Domain.EntitiesForManagement;

public class Building
{
    public Building()
    {
        Rooms = new HashSet<Room>();
    }
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public string ImageUrl { get; set; }
    //public virtual Address Address { get; set; }
    public string Description { get; set; }
    public int? TotalFloor { get; set; }
    public int? TotalRooms { get; set; }
    public int? CoordinateX { get; set; }
    public int? CoordinateY { get; set; }
    public int Status { get; set; }
    public int WardId { get; set; }
    public virtual Ward Ward { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}