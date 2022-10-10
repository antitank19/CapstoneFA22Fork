using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesDTO;

public class InvoiceGetDto
{
    public int InvoiceId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
    public int ContractId { get; set; }
    public virtual ContractGetDto Contract { get; set; }

    [ForeignKey("Sender")] public int SenderId { get; set; }

    public virtual AccountGetDto Sender { get; set; }
    public virtual ICollection<InvoiceHistoryGetDto> InvoiceHistories { get; set; }
    public virtual ICollection<BillGetDto> Bills { get; set; }
}