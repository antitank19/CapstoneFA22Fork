namespace Domain.EntitiesDTO;

public class PaymentTypeGetDto
{
    public int PaymentTypeId { get; set; }
    public string PaymentName { get; set; }
    public string PaymentStatus { get; set; }
    public virtual ICollection<PaymentGetDto> Payments { get; set; }
}