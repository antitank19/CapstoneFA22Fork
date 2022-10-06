using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class Payment
{
    public Payment()
    {
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentId { get; set; }
    public string Detail { get; set; }
    public float Amount { get; set; }
    public string Status { get; set; }
    public DateTime PaymentTime { get; set; }
    public TimeSpan PaymentPeriod { get; set; }
    public DateTime CreatedTime { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int PaymentTypeId { get; set; }
    public virtual PaymentType PaymentType { get; set; }
}