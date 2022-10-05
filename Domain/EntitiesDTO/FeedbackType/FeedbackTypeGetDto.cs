using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class FeedbackTypeGetDto
    {
        public int FeedbackTypeId { get; set; }
        public int Name { get; set; }
        public virtual ICollection<FeedbackGetDto> Feedbacks { get; set; }

    }
}
