using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesDTO.Bill;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace net6API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;
    public BillsController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Bills
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
    {
        return await _context.Bills.ToListAsync();
    }

    // GET: api/Bills/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Bill>> GetBill(int id)
    {
        var bill = await _context.Bills.FindAsync(id);

        if (bill == null) return NotFound();

        return bill;
    }

    // PUT: api/Bills/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBill(int id, Bill bill)
    {
        if (id != bill.BillId) 
            return BadRequest();

        var updateBill = new Bill()
        {
            BillId = id,
            Detail = bill.Detail,
            DueDate = bill.DueDate,
            InvoiceId = bill.InvoiceId,
        };

        var result = await _serviceWrapper.Bills.UpdateBill(updateBill);
        if (result == null) 
            return NotFound();
        
        return Ok("Bill updated successfully");
    }

    // POST: api/Bills
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bill>> PostBill(BillCreateDto bill)
    {
        var newBill = new Bill()
        {
            Name = bill.Name,
            Detail = bill.Detail,
            DueDate = bill.DueDate,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending),
            InvoiceId = bill.InvoiceId,
        };

        var result = await _serviceWrapper.Bills.AddBill(newBill);
        if (result == null)
            return NotFound();

        return CreatedAtAction("GetBill", new { id = newBill.BillId }, bill);
    }

    // DELETE: api/Bills/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBill(int id)
    {
        var result = await _serviceWrapper.Bills.DeleteBill(id);
        if (!result) 
            return NotFound();

        return Ok("Bill deleted successfully");
    }
}