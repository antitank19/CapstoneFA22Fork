namespace Domain.EntitiesDTO.OrderDetail;

public class OrderDetailUpdateDto
{
    public int OrderDetailId { get; set; }
    public float Amount { get; set; }
    public int OrderId { get; set; }
    public int ServiceId { get; set; }
}