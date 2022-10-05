using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class Request
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RequestId { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime SolveDate { get; set; }
    public int RequestTypeId { get; set; }
    public virtual RequestType RequestType { get; set; }
}