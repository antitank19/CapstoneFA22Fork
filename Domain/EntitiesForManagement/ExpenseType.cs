namespace Domain.EntitiesForManagement
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}