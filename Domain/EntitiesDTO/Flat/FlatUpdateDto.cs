using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class FlatUpdateDto
    {
        public int FlatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int FlatTypeId { get; set; }
        public int BuildingId { get; set; }
    }
}
