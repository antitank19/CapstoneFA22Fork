namespace Domain.EntitiesForManagement
{
    public class FlatType
    {
        public int FlatTypeId { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Flat> Flats { get; set; }

    }
}