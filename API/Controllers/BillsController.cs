﻿using AutoMapper;
using AutoMapper.AspNet.OData;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace API.Controllers;

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
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<BillGetDto>>> GetBills(ODataQueryOptions<BillGetDto>? options)
    {
        var list = _serviceWrapper.Bills.GetBillList();
        if (!list.Any())
            return NotFound("No bill available");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Bills/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BillGetDto>> GetBill(int id, ODataQueryOptions<BillGetDto>? options)
    {
        var list = _serviceWrapper.Bills.GetBillList()
            .Where(e => e.BillId == id);
        if (list.IsNullOrEmpty()) return NotFound("Bill not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Bills/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBill(int id, Bill bill)
    {
        if (id != bill.BillId)
            return BadRequest();

        var updateBill = new Bill
        {
            BillId = id,
            Detail = bill.Detail,
            DueDate = bill.DueDate,
            InvoiceId = bill.InvoiceId
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
        var newBill = new Bill
        {
            Name = bill.Name,
            Detail = bill.Detail,
            DueDate = bill.DueDate,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending),
            InvoiceId = bill.InvoiceId
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