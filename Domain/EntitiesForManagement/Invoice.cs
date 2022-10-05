using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Status { get; set; }
    public int ContractId { get; set; }
    public virtual Contract Contract { get; set; }

    [ForeignKey("Sender")] 
    public int SenderId { get; set; }

    public virtual Account Sender { get; set; }
    public virtual ICollection<InvoiceHistory> InvoiceHistories { get; set; }
    public virtual ICollection<Bill> Bills { get; set; }
}