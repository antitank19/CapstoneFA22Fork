using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class AreaUpdateDto
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ApartmentUpdateDto>? Appartments { get; set; }
    }
}
