namespace Domain.EntitiesForManagement;

public class RoomType
{
    public int RoomTypeId { get; set; }
    public string RoomName { get; set; }
    public string Status { get; set; }
    public virtual Room Room { get; set; }
}