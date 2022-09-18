namespace Domain.EntitiesForManagement;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Status { get; set; }
    public int RoleId { get; set; }
    public string Image { get; set; }
    public int UniversityId { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public virtual Role Role { get; set; }
    public virtual University University { get; set; }
}