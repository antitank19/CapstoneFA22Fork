namespace Domain.EntitiesForManagement;

public class Request
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime SolveDate { get; set; }
    public int RequestTypeId { get; set; }
    public virtual RequestType RequestType { get; set; }
}