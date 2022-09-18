namespace Domain.EntitiesForManagement;

public class Role
{
    public Role()
    {
        Users = new HashSet<User>();
    }

    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public virtual ICollection<User> Users { get; set; }
}