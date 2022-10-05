using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class AreaGetDto
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public virtual ICollection<AppartmentGetDto> Appartments { get; set; }

    }
}
