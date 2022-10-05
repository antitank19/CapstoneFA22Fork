namespace Domain.EntitiesForManagement;

public class FeedbackType
{
    public int FeedbackTypeId { get; set; }
    public int Name { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; }
}