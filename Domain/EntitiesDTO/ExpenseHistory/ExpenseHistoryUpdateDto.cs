using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ExpenseHistoryUpdateDto
    {
        public int ExpenseHistoryId { get; set; }
        public string Name { get; set; }
        public int ExpenseId { get; set; }
    }
}
