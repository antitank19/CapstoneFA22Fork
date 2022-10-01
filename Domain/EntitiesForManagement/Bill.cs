namespace Domain.EntitiesForManagement
{
    public class Bill
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }
}