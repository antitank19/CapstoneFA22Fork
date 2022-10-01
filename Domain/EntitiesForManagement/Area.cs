namespace Domain.EntitiesForManagement
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Status { get; set; }
        public virtual ICollection<Appartment> Appartments { get; set; }

    }
}