using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class PaymentType
{
    public PaymentType()
    {
        Payments = new HashSet<Payment>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentTypeId { get; set; }
    public string PaymentName { get; set; }
    public string PaymentStatus { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}