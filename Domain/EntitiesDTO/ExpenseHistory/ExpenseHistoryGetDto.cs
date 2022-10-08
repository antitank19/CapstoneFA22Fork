using Domain.EntitiesDTO.Expense;

namespace Domain.EntitiesDTO.ExpenseHistory;

public class ExpenseHistoryGetDto
{
    public int ExpenseHistoryId { get; set; }
    public string Name { get; set; }
    public int ExpenseId { get; set; }
    public virtual ExpenseGetDto Expense { get; set; }
}