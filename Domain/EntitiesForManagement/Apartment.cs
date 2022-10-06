using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Apartment
{
    public Apartment()
    {
        Buildings = new HashSet<Building>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApartmentId { get; set; }

    public string Name { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}