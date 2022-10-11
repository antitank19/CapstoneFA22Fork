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
public class InvoiceHistoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/InvoiceHistories
    public InvoiceHistoriesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<InvoiceHistory>>> GetInvoiceHistories(ODataQueryOptions<InvoiceHistoryGetDto>? options)
    {
        var list = _serviceWrapper.InvoiceHistories.GetInvoiceHistoryList();
        if (!list.Any())
            return NotFound("Invoice history not found");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/InvoiceHistories/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<InvoiceHistory>> GetInvoiceHistory(int id, ODataQueryOptions<InvoiceHistoryGetDto>? options)
    {
        var list = _serviceWrapper.InvoiceHistories.GetInvoiceHistoryList()
            .Where(x => x.InvoiceHistoryId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Invoice history not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/InvoiceHistories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutInvoiceHistory(int id, InvoiceHistoryUpdateDto invoiceHistory)
    {
        if (id != invoiceHistory.InvoiceHistoryId) return BadRequest();

        var updateInvoiceHistory = new InvoiceHistory()
        {
            InvoiceHistoryId = id,
            Name = invoiceHistory.Name,
            Image = invoiceHistory.Image,
            Detail = invoiceHistory.Detail,
            Status = invoiceHistory.Status,
            SendDate = invoiceHistory.SendDate,
            UpdatedDate = invoiceHistory.UpdatedDate,
            InvoiceId = invoiceHistory.InvoiceId,
        };
        
        var result = await _serviceWrapper.InvoiceHistories.UpdateInvoiceHistory(updateInvoiceHistory);
        if (result == null)
            return NotFound("Invoice history not found");

        return Ok("Invoice history updated successfully");
    }

    // POST: api/InvoiceHistories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InvoiceHistory>> PostInvoiceHistory(InvoiceHistoryCreateDto invoiceHistory)
    {
        var updateInvoiceHistory = new InvoiceHistory()
        {
            Name = invoiceHistory.Name,
            Image = invoiceHistory.Image,
            Detail = invoiceHistory.Detail,
            Status = invoiceHistory.Status,
            SendDate = invoiceHistory.SendDate,
            UpdatedDate = invoiceHistory.UpdatedDate,
            InvoiceId = invoiceHistory.InvoiceId,
        };
        var result = await _serviceWrapper.InvoiceHistories.UpdateInvoiceHistory(updateInvoiceHistory);
        if (result == null)
            return NotFound("Invoice history not found");
        return CreatedAtAction("GetInvoiceHistory", invoiceHistory);
    }

    // DELETE: api/InvoiceHistories/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInvoiceHistory(int id)
    {
        var result = await _serviceWrapper.InvoiceHistories.DeleteInvoiceHistory(id);
        if (!result)
            return NotFound("Invoice history not found");

        return Ok("Invoice history deleted");
    }
}