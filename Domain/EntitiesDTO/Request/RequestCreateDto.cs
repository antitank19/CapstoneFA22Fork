namespace Domain.EntitiesDTO;

public class RequestCreateDto
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime SolveDate { get; set; }
    public int RequestTypeId { get; set; }
}