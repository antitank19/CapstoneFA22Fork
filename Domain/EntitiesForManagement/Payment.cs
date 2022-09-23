namespace Domain.EntitiesForManagement;

public class Payment
{
    public Payment()
    {
        Transaction = new HashSet<Transaction>();
    }

    public int PaymentId { get; set; }
    public int Amount { get; set; }
    public string PaymentStatus { get; set; }
    public string PaymentContent { get; set; }
    public DateTime PaymentTime { get; set; }
    public int ContractId { get; set; }
    public int PaymentTypeId { get; set; }
    public int OwnerId { get; set; }
    public int UserId { get; set; } // who created the payment , User Id
    public TimeSpan PaymentPeriod { get; set; }
    public DateTime CreatedTime { get; set; }

    public virtual User User { get; set; }
    public virtual PaymentType PaymentType { get; set; }
    public virtual ICollection<Transaction> Transaction { get; set; }
}