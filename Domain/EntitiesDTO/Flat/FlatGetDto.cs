using Domain.EntitiesDTO.Contract;
using Domain.EntitiesDTO.FeedBack;
using Domain.EntitiesDTO.FlatType;

namespace Domain.EntitiesDTO.Flat;

public class FlatGetDto
{
    public int FlatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int FlatTypeId { get; set; }
    public virtual FlatTypeGetDto FlatType { get; set; }
    public int BuildingId { get; set; }
    public virtual BuildingGetDto Building { get; set; }
    public virtual ICollection<FeedbackGetDto> FeedBacks { get; set; }
    public virtual ICollection<ContractGetDto> Contracts { get; set; }
}