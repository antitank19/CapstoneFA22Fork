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
    public async Task<IActionResult> GetContractHistories(/*ODataQueryOptions<ContractHistoryGetDto>? options*/)
    {
        var list = _serviceWrapper.ContractHistories.GetContractHistoryList();
        if (!list.Any())
            return NotFound("No contract history available");

        //return Ok(await list.GetQueryAsync(_mapper, options));
        return Ok(_mapper.Map<List<ContractHistoryGetDto>>(list));
    }

    // GET: api/ContractHistories/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetContractHistory(int id /*,ODataQueryOptions<ContractHistoryGetDto>? options*//*ODataQueryOptions<ContractHistoryGetDto>? options*/)
    {
        //var list = _serviceWrapper.ContractHistories.GetContractHistoryList()
        //    .Where(e => e.ContractHistoryId == id);
        //if (list.IsNullOrEmpty())
        //    return NotFound("Contract history not found");
        //return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
        var entity = await _serviceWrapper.ContractHistories.GetContractHistoryById(id);
        if (entity == null)
            return NotFound("Contract history not found");
        var dto = _mapper.Map<ContractHistoryGetDto>(entity);
        return Ok(dto);
    }

    // PUT: api/ContractHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutContractHistory(int id, ContractHistoryCreateDto contractHistory)
    {
        if (id != contractHistory.ContractHistoryId)
            return BadRequest("Contract history id mismatch");

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
        var contractCheck = await _serviceWrapper.Contracts.GetContractById(contractHistory.ContractId);
        if (contractCheck == null)
            return NotFound("Contract not found");

        var addNewContractHistory = new ContractHistory
        {
            ContractId = contractHistory.ContractId,
            Description = contractHistory.Description,
            Price = contractHistory.Price,
            ContractHistoryStatus = contractHistory.ContractHistoryStatus,
            ContractExpiredDate = contractHistory.ContractExpiredDate
        };

        var result = await _serviceWrapper.ContractHistories.UpdateContractHistory(addNewContractHistory);
        if (result == null)
            return NotFound("Contract history not found");

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