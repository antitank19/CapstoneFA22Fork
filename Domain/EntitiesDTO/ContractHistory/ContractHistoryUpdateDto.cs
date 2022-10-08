namespace Domain.EntitiesDTO.ContractHistory;

public class ContractHistoryUpdateDto
{
    public int ContractHistoryId { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string ContractHistoryStatus { get; set; }
    public DateTime ContractExpiredDate { get; set; }
    public int ContractId { get; set; } // Contract
}