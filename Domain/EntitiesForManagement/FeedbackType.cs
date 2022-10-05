using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.EntitiesForManagement;

public class FeedbackType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackTypeId { get; set; }
    public int Name { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; }
}