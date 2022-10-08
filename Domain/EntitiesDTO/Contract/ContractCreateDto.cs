using Domain.EntitiesDTO.ContractHistory;

namespace Domain.EntitiesDTO.Contract;

public class ContractCreateDto
{
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public int FlatId { get; set; }
    public virtual ICollection<ContractHistoryCreateDto>? ContractHistories { get; set; }
}