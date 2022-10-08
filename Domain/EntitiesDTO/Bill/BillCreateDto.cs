namespace Domain.EntitiesDTO;

public class BillCreateDto
{
    public string Name { get; set; }
    public string Detail { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public int InvoiceId { get; set; }
}