namespace Domain.EntitiesForManagement;

public class Contract
{
    public Contract()
    {
        ContractHistory = new HashSet<ContractHistory>();
        Payment = new HashSet<Payment>();
    }

    public int ContractId { get; set; }
    public int UserId { get; set; } // User Id
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public virtual ICollection<Payment> Payment { get; set; }
    public virtual ICollection<ContractHistory> ContractHistory { get; set; }
}