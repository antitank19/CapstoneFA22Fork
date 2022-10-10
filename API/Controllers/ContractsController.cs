using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ContractsController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    // GET: api/Contracts
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contract>>> GetContracts(ODataQueryOptions<ContractGetDto>? options)
    {
        var list = await _serviceWrapper.Contracts.GetContractList().ToListAsync();
        if (!list.Any())
            return NotFound("No contract available");

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/Contracts/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contract>> GetContract(int id, ODataQueryOptions<ContractGetDto>? options)
    {
        var list = (await _serviceWrapper.Contracts.GetContractList().ToListAsync())
            .Where(e => e.ContractId == id).AsQueryable();
        if (list.IsNullOrEmpty() || !list.Any()) return NotFound("Contract not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
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

        var updateContract = new Contract
        {
            ContractId = contract.ContractId,
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            Description = contract.Description,
            LastUpdated = DateTime.Now,
            Price = contract.Price,
            ContractStatus = contract.ContractStatus,
            FlatId = contract.FlatId
        };

        var result1 = await _serviceWrapper.Contracts.UpdateContract(updateContract);
        if (result1 == null)
            return BadRequest();

        // Create another copy of contract history
        var addNewContractHistory = new ContractHistory
        {
            ContractId = contractDetail.ContractId,
            Description = contractDetail.Description,
            Price = contractDetail.Price,
            ContractHistoryStatus = contractDetail.ContractStatus,
            ContractExpiredDate = contractDetail.EndDate
        };

        var result2 = await _serviceWrapper.ContractHistories.AddContractHistory(addNewContractHistory);
        if (result2 == null)
            return BadRequest("Cannot add new contract history");

        return Ok("Contract updated");
    }

    // POST: api/Contracts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Contract>> PostContract(ContractCreateDto contract)
    {
        var newContract = new Contract
        {
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.Now,
            ContractStatus = contract.ContractStatus,
            Price = contract.Price,
            RenterId = contract.RenterId
            // TODO : get the current user id based on the token
        };

        var result = await _serviceWrapper.Contracts.AddContract(newContract);
        if (result == null)
            return NotFound();

        return CreatedAtAction("GetContract", new { id = contract.ContractId }, contract);
    }

    // DELETE: api/Contracts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContract(int id)
    {
        var result = await _serviceWrapper.Contracts.DeleteContract(id);
        if (!result)
            return NotFound("Contract not found");

        return Ok("Contract deleted");
    }
}