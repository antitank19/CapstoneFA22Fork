namespace Domain.EntitiesDTO;

public class ContractUpdateDto
{
    public int ContractId { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public int FlatId { get; set; }
}