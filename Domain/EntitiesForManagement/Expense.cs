using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Supervisor")]
        public int SupervisorId { get; set; }
        public virtual Account Supervisor { get; set; }
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}