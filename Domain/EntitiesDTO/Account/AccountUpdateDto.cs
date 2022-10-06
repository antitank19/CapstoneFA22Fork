using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO;

public class AccountUpdateDto
{
    public int AccountId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public int RoleId { get; set; }
}