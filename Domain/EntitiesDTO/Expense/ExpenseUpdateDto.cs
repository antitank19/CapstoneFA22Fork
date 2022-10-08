using Domain.EntitiesDTO.ExpenseHistory;

namespace Domain.EntitiesDTO.Expense;

public class ExpenseUpdateDto
{
    public int ExpenseId { get; set; }
    public string Name { get; set; }
    public int SupervisorId { get; set; }
    public int ExpenseTypeId { get; set; }
    public virtual ICollection<ExpenseHistoryUpdateDto>? ExpenseHistory { get; set; }
}