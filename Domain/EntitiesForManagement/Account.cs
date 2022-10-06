using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}