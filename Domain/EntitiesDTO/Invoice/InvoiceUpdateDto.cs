using Domain.EntitiesDTO.InvoiceHistory;

namespace Domain.EntitiesDTO.Invoice;

public class InvoiceUpdateDto
{
    public int InvoiceId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Status { get; set; }
    public int ContractId { get; set; }
    public int SenderId { get; set; }

    public virtual ICollection<InvoiceHistoryUpdateDto>? InvoiceHistories { get; set; }
}