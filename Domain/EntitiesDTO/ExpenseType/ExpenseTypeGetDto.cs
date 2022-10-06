using Domain.EntitiesForManagement;

namespace Domain.EntitiesDTO;

public class ExpenseTypeGetDto
{
    public int ExpenseTypeId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Status { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; }
}