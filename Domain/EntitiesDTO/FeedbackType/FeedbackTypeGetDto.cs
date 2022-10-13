namespace Domain.EntitiesDTO;

public class FeedbackTypeGetDto
{
    public int FeedbackTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<FeedbackGetDto> Feedbacks { get; set; }
}