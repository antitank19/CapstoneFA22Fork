using Domain.EntitiesDTO.InvoiceHistory;

namespace Domain.EntitiesDTO.Invoice;

public class InvoiceCreateDto
{
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Status { get; set; }
    public int ContractId { get; set; }
    public int SenderId { get; set; }

    public virtual ICollection<InvoiceHistoryCreateDto>? InvoiceHistories { get; set; }
}