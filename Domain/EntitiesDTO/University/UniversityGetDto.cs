using Domain.EntitiesDTO.Renter;

namespace Domain.EntitiesDTO.University;

public class UniversityGetDto
{
    public int UniversityId { get; set; }
    public string UniversityName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Status { get; set; }
    public string Address { get; set; }
    public virtual ICollection<RenterGetDto> Renters { get; set; }
}