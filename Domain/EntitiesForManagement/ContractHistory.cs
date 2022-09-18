using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ContractHistory
{
    public int ContractHistoryId { get; set; }

    [ForeignKey("UserId")] public int UserId { get; set; } // User

    public int OwnerId { get; set; } // User
    public int ContractId { get; set; } // Contract
    public float Price { get; set; }
    public string Description { get; set; }
    public string ContractHistoryStatus { get; set; }
    public DateTime ContractExpiredDate { get; set; }
    public virtual Contract Contract { get; set; }
    public virtual User User { get; set; }
}