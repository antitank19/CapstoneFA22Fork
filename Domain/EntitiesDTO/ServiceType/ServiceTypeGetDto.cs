using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ServiceTypeGetDto
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ServiceGetDto> Services { get; set; }

    }
}
