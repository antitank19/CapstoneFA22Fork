namespace Domain.EntitiesDTO;

public class OrderCreateDto
{
    public string Name { get; set; }
    public string Status { get; set; }
    public int RenterId { get; set; }
    public int RequestId { get; set; }
    public virtual ICollection<OrderDetailCreateDto>? Details { get; set; }
}