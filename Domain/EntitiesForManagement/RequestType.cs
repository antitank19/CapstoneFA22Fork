namespace Domain.EntitiesForManagement
{
    public class RequestType
    {
        public int RequestTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}