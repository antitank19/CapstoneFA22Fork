using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class RequestGetDto
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SolveDate { get; set; }
        public int RequestTypeId { get; set; }
        public virtual RequestTypeGetDto RequestType { get; set; }

    }
}
