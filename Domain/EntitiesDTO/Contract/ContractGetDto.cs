namespace Domain.EntitiesDTO;

public class ContractGetDto
{
    public int ContractId { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public int FlatId { get; set; }
    public FlatGetDto Flat { get; set; }
    public virtual ICollection<InvoiceGetDto> Invoices { get; set; }
    public virtual ICollection<ContractHistoryGetDto> ContractHistories { get; set; }
}