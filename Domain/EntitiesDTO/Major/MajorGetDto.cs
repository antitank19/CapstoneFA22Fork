using Domain.EntitiesDTO.Renter;

namespace Domain.EntitiesDTO.Major;

public class MajorGetDto
{
    public int MajorId { get; set; }

    public string Name { get; set; }
    public virtual ICollection<RenterGetDto> Renters { get; set; }
}