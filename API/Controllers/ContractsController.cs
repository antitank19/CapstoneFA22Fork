using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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
    public async Task<IActionResult/*<IQueryable<ContractGetDto>>*/> GetContracts(ODataQueryOptions<ContractGetDto>? options)
    {
        var list = _serviceWrapper.Contracts.GetContractList();
        if (!list.Any())
            return NotFound("No contract available");

        //return Ok(await list.GetQueryAsync(_mapper, options));
        return Ok(_mapper.Map<List<ContractGetDto>>(list));
    }

    // GET: api/Contracts/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContract(int id/*, ODataQueryOptions<ContractGetDto>? options*/)
    {
        //var list = _serviceWrapper.Contracts.GetContractList()
        //    .Where(e => e.ContractId == id);
        //if (list.IsNullOrEmpty() || !list.Any()) return NotFound("Contract not found");
        //return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
        var entity = await _serviceWrapper.Contracts.GetContractById(id);
        if (entity == null)
            return NotFound("Contract not found");
        var dto = _mapper.Map<ContractGetDto>(entity);
        return Ok(dto);
    }

    [HttpGet("{id:int}/user")]
    public async Task<ActionResult<Contract>> GetContractByUserId(int userId)
    {
        return Ok();
    }
    
    // PUT: api/Contracts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContract(int id, ContractUpdateDto contract)
    {
        if (id != contract.ContractId)
            return BadRequest("Contract id mismatch");

        var contractDetail = await _serviceWrapper.Contracts.GetContractById(id);

        if (contractDetail == null)
            return NotFound("Contract not found");

        var flatCheck = await FlatCheck(contract.FlatId);
        if (flatCheck == null)
            return NotFound("Flat not found");

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
        
        var dateCheck = DateRemainingCheck(updateContract.StartDate, updateContract.EndDate);
        switch (dateCheck)
        {
            case <0:
                return BadRequest("Start date must be before end date");
            case <7:
                return BadRequest("Start date and end date is less than one week");
            case <30:
                return BadRequest("Start date and end date is less than one month");
        }

        var result1 = await _serviceWrapper.Contracts.UpdateContract(updateContract);
        if (result1 == null)
            return BadRequest("Contract update failed");

        // Create another copy of contract history
        var addNewContractHistory = new ContractHistory
        {
            ContractId = result1.ContractId,
            Description = result1.Description,
            Price = result1.Price,
            ContractHistoryStatus = result1.ContractStatus,
            ContractExpiredDate = result1.EndDate
        };

        var result2 = await _serviceWrapper.ContractHistories.AddContractHistory(addNewContractHistory);
        if (result2 == null)
            return BadRequest("Cannot add new contract history");

        return Ok("Contract updated");
    }

    // POST: api/Contracts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("sign")]
    public async Task<ActionResult<Contract>> PostContract(ContractCreateDto contract)
    {
        var renterCheck = await RenterCheck(contract.RenterId);
        if (renterCheck == null)
            return NotFound("Renter not found");

        var flatCheck = await FlatCheck(contract.FlatId);
        if (flatCheck == null)
            return NotFound("Flat not found");

        var newContract = new Contract
        {
            DateSigned = contract.DateSigned,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            LastUpdated = DateTime.UtcNow,
            ContractStatus = contract.ContractStatus,
            Price = contract.Price,
            RenterId = contract.RenterId,
            FlatId = contract.FlatId,
            Description = contract.Description
            // TODO : get the current user id based on the token
        };
        
        if (newContract.Price < 0)
            return BadRequest("Price must be greater than 0 and an integer");
        
        var dateCheck = DateRemainingCheck(newContract.StartDate, newContract.EndDate);
        switch (dateCheck)
        {
            case <0:
                return BadRequest("Start date must be before end date");
            case <7:
                return BadRequest("Start date and end date is less than one week");
            case <30:
                return BadRequest("Start date and end date is less than one month");
        }

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
    
    private async Task<Flat?> FlatCheck(int id)
    {
        return await _serviceWrapper.Flats.GetFlatById(id) ?? null;
    }

    private async Task<Renter?> RenterCheck(int id)
    {
        return await _serviceWrapper.Renters.GetRenterById(id) ?? null;
    }

    private static int DateRemainingCheck(DateTime start, DateTime end)
    {
        return (start.Date - end.Date).Days + 1;
    }

}