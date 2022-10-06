using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Contract
{
    public Contract()
    {
        ContractHistories = new HashSet<ContractHistory>();
        Invoices = new HashSet<Invoice>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractId { get; set; }

    public int UserId { get; set; } // User Id
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public float Price { get; set; }
    public int FlatId { get; set; }
    public Flat Flat { get; set; }
    public virtual Renter Renter { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<ContractHistory> ContractHistories { get; set; }
}