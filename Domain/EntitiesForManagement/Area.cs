using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Area
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AreaId { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Apartment> Appartments { get; set; }
}