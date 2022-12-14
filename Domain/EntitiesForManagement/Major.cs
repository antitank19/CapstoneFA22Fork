using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Major
{
    public Major()
    {
        Renters = new HashSet<Renter>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MajorId { get; set; }

    public string Name { get; set; }
    public virtual ICollection<Renter> Renters { get; set; }
}