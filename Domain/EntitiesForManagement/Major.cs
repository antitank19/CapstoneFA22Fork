using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class Major
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MajorId { get; set; }
    public string Name { get; set; }
}