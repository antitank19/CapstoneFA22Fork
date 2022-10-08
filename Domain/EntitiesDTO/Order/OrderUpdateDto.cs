using Domain.EntitiesDTO.OrderDetail;

namespace Domain.EntitiesDTO.Order;

public class OrderUpdateDto
{
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public int RenterId { get; set; }
    public int RequestId { get; set; }
    public virtual ICollection<OrderDetailUpdateDto>? Details { get; set; }
}