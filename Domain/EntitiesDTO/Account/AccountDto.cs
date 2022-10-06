namespace Domain.EntitiesDTO.Account;

public class AccountDto
{
    public int AccountId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
}