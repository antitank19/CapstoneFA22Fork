namespace Domain.EntitiesDTO;

public class InvoiceHistoryUpdateDto
{
    public int InvoiceHistoryId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Status { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Image { get; set; }
    public int InvoiceId { get; set; }
}