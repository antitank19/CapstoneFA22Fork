namespace Domain.EntitiesForManagement;

public class Room
{
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public string Description { get; set; }
    public int ContractId { get; set; }
    public int RoomTypeId { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
}