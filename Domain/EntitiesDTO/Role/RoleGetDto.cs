using Domain.EntitiesDTO.Account;

namespace Domain.EntitiesDTO.Role;

public class RoleGetDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<AccountGetDto> Accounts { get; set; }
}