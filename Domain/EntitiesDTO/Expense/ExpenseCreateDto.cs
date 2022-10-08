using Domain.EntitiesDTO.ExpenseHistory;

namespace Domain.EntitiesDTO.Expense;

public class ExpenseCreateDto
{
    public string Name { get; set; }
    public int SupervisorId { get; set; }
    public int ExpenseTypeId { get; set; }
    public virtual ICollection<ExpenseHistoryCreateDto>? ExpenseHistory { get; set; }
}