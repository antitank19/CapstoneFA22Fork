namespace Domain.EntitiesDTO;

public class RenterGetDto
{
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

    //public int UniversityId { get; set; }
    public virtual UniversityGetDto University { get; set; }

    //public int MajorId { get; set; }
    public virtual MajorGetDto Major { get; set; }
    //public virtual ICollection<ContractGetDto> Contracts { get; set; }
    //public virtual ICollection<OrderGetDto> Orders { get; set; }
}