using Domain.EntitiesDTO.Flat;
using Domain.EntitiesDTO.Invoice;

namespace Domain.EntitiesDTO.ContractHistory;

public class ContractHistoryCreateDto
{
    public int UserId { get; set; } // User Id
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public int FlatId { get; set; }
    public FlatGetDto Flat { get; set; }
    public virtual ICollection<InvoiceCreateDto> Invoices { get; set; }
    public virtual ICollection<ContractHistoryCreateDto> ContractHistories { get; set; }
}