using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class OrderUpdateDto
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int RenterId { get; set; }
        public int RequestId { get; set; }
        public virtual ICollection<OrderDetailUpdateDto>? Details { get; set; }

    }
}
