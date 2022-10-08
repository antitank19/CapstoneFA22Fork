using Domain.EntitiesDTO.Flat;

namespace Domain.EntitiesDTO.FlatType;

public class FlatTypeGetDto
{
    public int FlatTypeId { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }
    public virtual ICollection<FlatGetDto> Flats { get; set; }
}