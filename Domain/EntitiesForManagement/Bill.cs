using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Bill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BillId { get; set; }

    public string Name { get; set; }
    public string Detail { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; }
}