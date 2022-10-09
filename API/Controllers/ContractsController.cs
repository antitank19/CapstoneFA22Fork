using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ContractsController(IMapper mapper, IServiceWrapper serviceWrapper, ApplicationContext context)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
        _context = context;
    }

    // GET: api/Contracts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
    {
        return await _context.Contracts.ToListAsync();
    }

    // GET: api/Contracts/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contract>> GetContract(int id)
    {
        var contract = await _context.Contracts.FindAsync(id);

        if (contract == null) return NotFound();

        return contract;
    }

    // PUT: api/Contracts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, ContractUpdateDto contract)
    {
        if (id != contract.ContractId) 
            return BadRequest();
        
        var contractDetail = await _serviceWrapper.Contracts.GetContractById(id);
        
        if (contractDetail == null) 
            return NotFound();
        
        var updateContract = new Contract()
        {
            ContractId = contract.ContractId,
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            Description = contract.Description,
            LastUpdated = DateTime.Now,
            Price = contract.Price,
            ContractStatus = contract.ContractStatus,
            FlatId = contract.FlatId,
        };
        
        // Create another copy of contract history
        
        var addNewContractHistory = new ContractHistory()
        {
            ContractId = contractDetail.ContractId,
            Description = contractDetail.Description,
            Price = contractDetail.Price,
        };

        return Ok("Contract updated");
    }

    // POST: api/Contracts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Contract>> PostContract(ContractCreateDto contract)
    {
        var newContract = new Contract()
        {
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.Now,
            ContractStatus = contract.ContractStatus,
            Price = contract.Price,
            RenterId = contract.RenterId,
            // TODO : get the current user id based on the token
        };
        
        var result = await _serviceWrapper.Contracts.AddContract(newContract);
        if (result == null) 
            return NotFound();
        
        return CreatedAtAction("GetContract", new { id = newContract.ContractId }, contract);
    }

    // DELETE: api/Contracts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var result = await _serviceWrapper.Contracts.DeleteContract(id);
        if (!result)
            return NotFound("Contract not found");
        
        return Ok( "Contract deleted");
    }

    private bool ContractExists(int id)
    {
        return _context.Contracts.Any(e => e.ContractId == id);
    }
}