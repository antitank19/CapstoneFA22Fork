using Domain.EntitiesDTO.Expense;

namespace Domain.EntitiesDTO.ExpenseType;

public class ExpenseTypeGetDto
{
    public int ExpenseTypeId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Status { get; set; }
    public virtual ICollection<ExpenseGetDto> Expenses { get; set; }
}