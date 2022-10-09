namespace Domain.EntitiesDTO;

public class PaymentCreateDto
{
    public int PaymentId { get; set; }
    public string Detail { get; set; }
    public float Amount { get; set; }
    public string Status { get; set; }
    public DateTime PaymentTime { get; set; }
    public TimeSpan PaymentPeriod { get; set; }
    public DateTime CreatedTime { get; set; }
    public int PaymentTypeId { get; set; }
}