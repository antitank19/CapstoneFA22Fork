namespace Domain.EntitiesForManagement;

public class RentEntity
{
    public int RentEntityId { get; set; }
    public string Username { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public string ImageUrl { get; set; }
    public int RoomId { get; set; }
    public float Price { get; set; }
    public string Status { get; set; }
    public DateTime UpdatedDate { get; set; }
    public virtual Room Room { get; set; }
    public virtual User User { get; set; }
}