using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Domain.EntitiesForManagement;

public class Major
{
    public Major()
    {
        Renters = new HashSet<Renter>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int MajorId { get; set; }

    public string Name { get; set; }
    public virtual ICollection<Renter> Renters { get; set; }
}