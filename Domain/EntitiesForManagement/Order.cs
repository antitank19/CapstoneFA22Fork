using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Order
{
    public Order()
    {
        Details = new HashSet<OrderDetail>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    public string Name { get; set; }
    public string Status { get; set; }
    public int RenterId { get; set; }
    public Renter Renter { get; set; }
    public int RequestId { get; set; }
    public virtual Request Request { get; set; }
    public virtual ICollection<OrderDetail> Details { get; set; }
}