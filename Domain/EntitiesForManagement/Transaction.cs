namespace Domain.EntitiesForManagement;

public class Transaction
{
    public int TransactionId { get; set; }
    public int EncryptedTransactionHash { get; set; }
    public string ContractStatus { get; set; }
    public int TransactionTime { get; set; }
    public int PaymentId { get; set; }
    public virtual Payment Payment { get; set; }
}