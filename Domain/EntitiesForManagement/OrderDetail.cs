using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailId { get; set; }

    public float Amount { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    [ForeignKey("Service")] public int ServiceId { get; set; }

    public virtual ServiceEntity Service { get; set; }
}