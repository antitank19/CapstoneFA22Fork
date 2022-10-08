namespace Domain.EntitiesDTO.ExpenseHistory;

public class ExpenseHistoryUpdateDto
{
    public int ExpenseHistoryId { get; set; }
    public string Name { get; set; }
    public int ExpenseId { get; set; }
}