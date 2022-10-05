using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class FlatTypeGetDto
    {
        public int FlatTypeId { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
