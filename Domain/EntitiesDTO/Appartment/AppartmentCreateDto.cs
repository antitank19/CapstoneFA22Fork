using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class AppartmentCreateDto
    {
        public int AppartmentId { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public virtual ICollection<BuildingGetDto> Buildings { get; set; }
    }
}
