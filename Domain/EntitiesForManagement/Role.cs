using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class Role
{
    public Role()
    {
        Accounts = new HashSet<Account>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
}