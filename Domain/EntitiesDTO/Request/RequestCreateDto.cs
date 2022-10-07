using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class RequestCreateDto
    {
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SolveDate { get; set; }
        public int RequestTypeId { get; set; }
    }
}
