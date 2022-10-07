using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class PaymentTypeUpdateDto
    {
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
