using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    class ServiceTypeCreate
    {
        public string Name { get; set; }
        public virtual ICollection<ServiceCreateDto> Services { get; set; }
    }
}
