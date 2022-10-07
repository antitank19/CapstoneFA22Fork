using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ExpenseTypeUpdateDto
    {
        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
    }
}
