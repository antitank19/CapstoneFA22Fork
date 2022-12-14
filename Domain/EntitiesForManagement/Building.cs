using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Building
{
    public Building()
    {
        Flats = new HashSet<Flat>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BuildingId { get; set; }

    public string BuildingName { get; set; }

    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int? TotalFloor { get; set; }
    public int? TotalRooms { get; set; }
    public int? CoordinateX { get; set; }
    public int? CoordinateY { get; set; }
    public bool Status { get; set; }

    [ForeignKey("Apartment")] public int ApartmentId { get; set; }

    public virtual Apartment Apartment { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}