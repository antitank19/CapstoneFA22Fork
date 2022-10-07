using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ExpenseUpdateDto
    {
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        public int SupervisorId { get; set; }
        public int ExpenseTypeId { get; set; }
        public virtual ICollection<ExpenseHistoryUpdateDto>? ExpenseHistory { get; set; }
    }
}
