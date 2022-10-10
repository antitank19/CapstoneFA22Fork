namespace Domain.EntitiesDTO;

public class ExpenseCreateDto
{
    public int ExpenseId { get; set; }
    public string Name { get; set; }
    public int SupervisorId { get; set; }
    public int ExpenseTypeId { get; set; }
    public virtual ICollection<ExpenseHistoryCreateDto>? ExpenseHistory { get; set; }
}