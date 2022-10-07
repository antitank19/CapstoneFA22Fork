using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class FeedbackCreateDto
    {
        public int FeedbackId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int FlatId { get; set; }
        public int RenterId { get; set; }
        public int FeedbackTypeId { get; set; }
    }
}
