using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ExpenseGetDto
    {
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Supervisor")]
        public int SupervisorId { get; set; }
        public virtual AccountGetDto Supervisor { get; set; }
        public int ExpenseTypeId { get; set; }
        public virtual ExpenseTypeGetDto ExpenseType { get; set; }
        public virtual ICollection<ExpenseHistoryGetDto> ExpenseHistory { get; set; }

    }
}
