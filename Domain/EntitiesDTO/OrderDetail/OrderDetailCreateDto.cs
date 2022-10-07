using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class OrderDetailCreateDto
    {
        public float Amount { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
    }
}
