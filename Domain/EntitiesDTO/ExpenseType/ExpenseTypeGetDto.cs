namespace Domain.EntitiesDTO;

public class ExpenseTypeGetDto
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string Status { get; set; }
    public virtual ICollection<ExpenseGetDto> Expenses { get; set; }
}