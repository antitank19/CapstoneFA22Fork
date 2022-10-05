using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class ContractHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractHistoryId { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string ContractHistoryStatus { get; set; }
    public DateTime ContractExpiredDate { get; set; }
    public int ContractId { get; set; } // Contract
    public virtual Contract Contract { get; set; }
}