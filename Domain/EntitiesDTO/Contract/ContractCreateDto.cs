namespace Domain.EntitiesDTO;

public class ContractCreateDto
{
    public int ContractId { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Description { get; set; }
    public string ContractStatus { get; set; }
    public float Price { get; set; }
    public int RenterId { get; set; } // User Id
    public int FlatId { get; set; }
}