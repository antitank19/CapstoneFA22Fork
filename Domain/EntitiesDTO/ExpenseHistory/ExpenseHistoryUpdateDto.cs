namespace Domain.EntitiesDTO;

public class ExpenseHistoryUpdateDto
{
    public int ExpenseHistoryId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public int ExpenseId { get; set; }
}