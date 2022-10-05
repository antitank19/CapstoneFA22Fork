using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class University
{
    public University()
    {
        Users = new HashSet<Renter>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UniversityId { get; set; }
    public string UniversityName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Renter> Users { get; set; }
}