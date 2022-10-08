using Domain.EntitiesDTO.Order;
using Domain.EntitiesDTO.PaymentType;

namespace Domain.EntitiesDTO.Payment;

public class PaymentGetDto
{
    public int PaymentId { get; set; }
    public string Detail { get; set; }
    public float Amount { get; set; }
    public string Status { get; set; }
    public DateTime PaymentTime { get; set; }
    public TimeSpan PaymentPeriod { get; set; }
    public DateTime CreatedTime { get; set; }
    public int OrderId { get; set; }
    public virtual OrderGetDto Order { get; set; }
    public int PaymentTypeId { get; set; }
    public virtual PaymentTypeGetDto PaymentType { get; set; }
}