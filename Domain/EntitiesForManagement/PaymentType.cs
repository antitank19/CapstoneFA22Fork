using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public string Name { get; set; }
    public string Status { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}