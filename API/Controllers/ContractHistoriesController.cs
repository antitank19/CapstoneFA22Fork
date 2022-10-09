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
public class ContractHistoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public ContractHistoriesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }


    // GET: api/ContractHistories
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractHistory>>> GetContractHistories(
        ODataQueryOptions<AccountGetDto>? options)
    {
        var list = await _serviceWrapper.ContractHistories.GetContractHistoryList();
        if (!list.Any())
            return NotFound("No contract history available");

        return Ok(await list.AsQueryable().GetQueryAsync(_mapper, options));
    }

    // GET: api/ContractHistories/5
    [EnableQuery]
    [HttpGet("{id}")]
    public async Task<ActionResult<ContractHistory>> GetContractHistory(int id,
        ODataQueryOptions<AccountGetDto>? options)
    {
        var list = (await _serviceWrapper.ContractHistories.GetContractHistoryList())
            .Where(e => e.ContractHistoryId == id).AsQueryable();
        if (list.IsNullOrEmpty()) return NotFound("Contract history not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/ContractHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContractHistory(int id, ContractHistoryCreateDto contractHistory)
    {
        if (id != contractHistory.ContractHistoryId)
            return BadRequest();

        var updateContract = new ContractHistory
        {
            ContractHistoryId = id,
            Description = contractHistory.Description,
            ContractHistoryStatus = contractHistory.ContractHistoryStatus,
            ContractExpiredDate = contractHistory.ContractExpiredDate,
            Price = contractHistory.Price
        };

        var result1 = await _serviceWrapper.ContractHistories.UpdateContractHistory(updateContract);
        if (result1 == null)
            return NotFound("Contract history not found");

        return Ok("Contract history updated successfully");
    }

    // POST: api/ContractHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ContractHistory>> PostContractHistory(ContractHistoryCreateDto contractHistory)
    {
        var addNewContractHistory = new ContractHistory
        {
            ContractId = contractHistory.ContractId,
            Description = contractHistory.Description,
            Price = contractHistory.Price,
            ContractHistoryStatus = contractHistory.ContractHistoryStatus,
            ContractExpiredDate = contractHistory.ContractExpiredDate
        };

        return CreatedAtAction("GetContractHistory", new { id = contractHistory.ContractHistoryId }, contractHistory);
    }

    // DELETE: api/ContractHistories/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteContractHistory(int id)
    {
        var result = await _serviceWrapper.ContractHistories.DeleteContractHistory(id);

        if (!result)
            return NotFound("Contract history not found");

        return Ok("Contract history deleted successfully");
    }
}