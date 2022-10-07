using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    internal class BuldingUpdateDto
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int? TotalFloor { get; set; }
        public int? TotalRooms { get; set; }
        public int? CoordinateX { get; set; }
        public int? CoordinateY { get; set; }
        public int Status { get; set; }
        public int AppartmentId { get; set; }
        public virtual ICollection<FlatUpdateDto>? Flats { get; set; }
    }
}
