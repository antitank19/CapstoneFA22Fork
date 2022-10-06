using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Renter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RenterId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Status { get; set; }
    public string Image { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public int UniversityId { get; set; }
    public virtual University University { get; set; }
    public int MajorId { get; set; }
    public Major Major { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}