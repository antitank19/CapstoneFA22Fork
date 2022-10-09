using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class University
{
    public University()
    {
        Renters = new HashSet<Renter>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UniversityId { get; set; }

    public string UniversityName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string? Status { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Renter> Renters { get; set; }
}