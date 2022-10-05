namespace Domain.EntitiesForManagement;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public float Amount { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int ServiceId { get; set; }
    public virtual ServiceEntity ServiceEntity { get; set; }
}