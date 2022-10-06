using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Expense
{
    public Expense()
    {
        ExpenseHistory = new HashSet<ExpenseHistory>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExpenseId { get; set; }

    public string Name { get; set; }

    [ForeignKey("Supervisor")] public int SupervisorId { get; set; }

    public virtual Account Supervisor { get; set; }
    public int ExpenseTypeId { get; set; }
    public virtual ExpenseType ExpenseType { get; set; }
    public virtual ICollection<ExpenseHistory> ExpenseHistory { get; set; }
}