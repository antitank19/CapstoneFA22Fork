using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ServiceEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceEntityId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int ServiceTypeId { get; set; }
    public virtual ServiceType ServiceType { get; set; }
}