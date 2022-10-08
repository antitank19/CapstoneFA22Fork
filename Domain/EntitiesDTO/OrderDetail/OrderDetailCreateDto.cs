namespace Domain.EntitiesDTO.OrderDetail;

public class OrderDetailCreateDto
{
    public float Amount { get; set; }
    public int OrderId { get; set; }
    public int ServiceId { get; set; }
}