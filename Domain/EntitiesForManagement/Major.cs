using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Major
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MajorId { get; set; }

    public string Name { get; set; }
}