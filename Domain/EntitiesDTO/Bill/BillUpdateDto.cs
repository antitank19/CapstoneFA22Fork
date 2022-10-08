namespace Domain.EntitiesDTO;

public class BillUpdateDto
{
    public int BillId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public int InvoiceId { get; set; }
}