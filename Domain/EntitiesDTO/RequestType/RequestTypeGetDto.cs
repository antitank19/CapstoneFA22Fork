using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class RequestTypeGetDto
    {
        public int RequestTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RequestGetDto> Requests { get; set; }

    }
}
