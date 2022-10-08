namespace Domain.EntitiesDTO;

public class RenterCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public string Image { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int UniversityId { get; set; }
    public int MajorId { get; set; }
}