using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ContractHistory
{
    public int ContractHistoryId { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string ContractHistoryStatus { get; set; }
    public DateTime ContractExpiredDate { get; set; }
    public int ContractId { get; set; } // Contract
    public virtual Contract Contract { get; set; }
}