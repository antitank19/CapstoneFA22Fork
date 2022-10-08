using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ExpenseType
{
    public ExpenseType()
    {
        Expenses = new HashSet<Expense>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExpenseTypeId { get; set; }

    public string Name { get; set; }
    public float Price { get; set; }
    public string Status { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; }
}