namespace Domain.EntitiesDTO;

public class ExpenseGetDto
{
    public int ExpenseId { get; set; }
    public string Name { get; set; }
    public int SupervisorId { get; set; }

    public virtual AccountGetDto Supervisor { get; set; }
    public int ExpenseTypeId { get; set; }
    public virtual ExpenseTypeGetDto ExpenseType { get; set; }
    public virtual ICollection<ExpenseHistoryGetDto> ExpenseHistories { get; set; }
}