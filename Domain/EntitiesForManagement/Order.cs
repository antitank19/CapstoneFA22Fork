namespace Domain.EntitiesForManagement;

public class Order
{
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public int RenterId { get; set; }
    public Renter Renter { get; set; }
    public int RequestId { get; set; }
    public virtual Request Request { get; set; }
    public virtual ICollection<OrderDetail> Details { get; set; }
}