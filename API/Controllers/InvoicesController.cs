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
public class InvoicesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/Invoices
    public InvoicesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices(ODataQueryOptions<InvoiceGetDto>? options)
    {
        var list = _serviceWrapper.Invoices.GetInvoiceList();
        if (!list.Any())
            return NotFound("No invoice available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Invoices/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Invoice>> GetInvoice(int id, ODataQueryOptions<InvoiceGetDto>? options)
    {
        var list = _serviceWrapper.Invoices.GetInvoiceList()
            .Where(x => x.InvoiceId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Invoice not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Invoices/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutInvoice(int id, InvoiceUpdateDto invoice)
    {
        if (id != invoice.InvoiceId) return BadRequest();

        var updateInvoice = new Invoice()
        {
            InvoiceId = id,
            Name = invoice.Name,
            Image = invoice.Image,
            Detail = invoice.Detail,
            SenderId = invoice.SenderId,
            ContractId = invoice.ContractId,
        };
        
        var result1 = await _serviceWrapper.Invoices.UpdateInvoice(updateInvoice);
        if (result1 == null)
            return NotFound("Invoice failed to update");
        
        var updateInvoiceHistory = new InvoiceHistory()
        {
            Name = updateInvoice.Name,
            Image = updateInvoice.Image,
            Detail = updateInvoice.Detail,
            Status = updateInvoice.Status,
            UpdatedDate = DateTime.Now,
            InvoiceId = updateInvoice.InvoiceId,
        };
        var result2 = await _serviceWrapper.InvoiceHistories.AddInvoiceHistory(updateInvoiceHistory);
        if (result2 == null)
            return NotFound("Invoice history failed to add");
        
        return Ok("Invoice updated successfully");
    }

    // POST: api/Invoices
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Invoice>> PostInvoice(InvoiceCreateDto invoice)
    {
        var addNewInvoice = new Invoice()
        {   
            Name = invoice.Name,
            Image = invoice.Image,
            Detail = invoice.Detail,
            SenderId = invoice.SenderId,
            ContractId = invoice.ContractId,
        };
        var result = await _serviceWrapper.Invoices.AddInvoice(addNewInvoice);
        if (result == null)
            return NotFound("Invoice not found");
       
        return CreatedAtAction("GetInvoice", invoice);
    }

    // DELETE: api/Invoices/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _serviceWrapper.Invoices.DeleteInvoice(id);
        if (!result)
            return NotFound("Invoice not found");

        return Ok("Invoice deleted");
    }
}