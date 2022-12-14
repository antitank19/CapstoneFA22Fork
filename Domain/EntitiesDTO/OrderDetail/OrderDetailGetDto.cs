namespace Domain.EntitiesDTO;

public class OrderDetailGetDto
{
    public int OrderDetailId { get; set; }
    public float Amount { get; set; }
    public int OrderId { get; set; }
    public virtual OrderGetDto Order { get; set; }
    public int ServiceId { get; set; }
    public virtual ServiceGetDto Service { get; set; }
}