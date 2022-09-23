namespace Domain.EntitiesForManagement;

public class Owner
{
    public Owner()
    {
        Rooms = new HashSet<Room>();
    }

    public int OwnerId { get; set; }
    public string OwnerName { get; set; }
    public int OwnerPhone { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}