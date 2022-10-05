namespace Domain.EntitiesForManagement;

public class Feedback
{
    public int FeedbackId { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }
    public int FeedbackTypeId { get; set; }
    public int RenterId { get; set; }
    public Renter Renter { get; set; }
    public virtual FeedbackType FeedbackType { get; set; }
}