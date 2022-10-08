using Domain.EntitiesDTO.FeedBack;

namespace Domain.EntitiesDTO.FeedbackType;

public class FeedbackTypeGetDto
{
    public int FeedbackTypeId { get; set; }
    public int Name { get; set; }
    public virtual ICollection<FeedbackGetDto> Feedbacks { get; set; }
}