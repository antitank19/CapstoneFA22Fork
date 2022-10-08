using Domain.EntitiesDTO.OrderDetail;
using Domain.EntitiesDTO.Renter;
using Domain.EntitiesDTO.Request;

namespace Domain.EntitiesDTO.Order;

public class OrderGetDto
{
    public int OrderId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public int RenterId { get; set; }
    public RenterGetDto Renter { get; set; }
    public int RequestId { get; set; }
    public virtual RequestGetDto Request { get; set; }
    public virtual ICollection<OrderDetailGetDto> Details { get; set; }
}