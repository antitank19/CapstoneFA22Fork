namespace Domain.EntitiesDTO;

public class FeedbackUpdateDto
{
    public int FeedbackId { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public int FlatId { get; set; }
    public virtual FlatGetDto Flat { get; set; }
    public int FeedbackTypeId { get; set; }
    public int RenterId { get; set; }
}