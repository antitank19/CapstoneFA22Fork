namespace Domain.EntitiesDTO.FeedBack;

public class FeedbackCreateDto
{
    public int FeedbackId { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public int FlatId { get; set; }

    public int RenterId { get; set; }

    //public RenterGetDto Renter { get; set; }
    public int FeedbackTypeId { get; set; }
}