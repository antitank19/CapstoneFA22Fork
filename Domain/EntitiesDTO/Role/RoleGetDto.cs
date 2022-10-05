using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO;

public class RoleGetDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<AccountGetDto> Accounts { get; set; }

}