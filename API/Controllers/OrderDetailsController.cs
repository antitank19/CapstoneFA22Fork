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
public class OrderDetailsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public OrderDetailsController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/OrderDetails
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<OrderDetailGetDto>>> GetOrderDetails(ODataQueryOptions<OrderDetail>? options)
    {
        var list = _serviceWrapper.OrderDetails.GetOrderDetailList();
        if (!list.Any())
            return NotFound("No Order Details Found");

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/OrderDetails/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<OrderDetailGetDto>> GetOrderDetail(int id, ODataQueryOptions<OrderDetail>? options)
    {
        var list = _serviceWrapper.OrderDetails.GetOrderDetailList()
            .Where(x => x.OrderDetailId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Order detail not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/OrderDetails/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutOrderDetail(int id, OrderDetailUpdateDto orderDetail)
    {
        if (id != orderDetail.OrderDetailId) 
            return BadRequest("Id mismatch");
        var orderCheck = await _serviceWrapper.Orders.GetOrderById(orderDetail.OrderId);
        if (orderCheck == null)
            return NotFound("Order not found");
        
        var updateOrderDetail = new OrderDetail
        {
            OrderDetailId = id,
            Amount = orderDetail.Amount,
            OrderId = orderDetail.OrderId,
            ServiceId = orderDetail.ServiceId
        };
        var result = await _serviceWrapper.OrderDetails.UpdateOrderDetail(updateOrderDetail);
        if (result == null)
            return NotFound("Order detail not found");
        return Ok("Order detail updated successfully");
    }

    // POST: api/OrderDetails
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetailCreateDto orderDetail)
    {
        var newOrderDetail = new OrderDetail
        {
            Amount = orderDetail.Amount,
            OrderId = orderDetail.OrderId,
            ServiceId = orderDetail.ServiceId
        };
        var result = await _serviceWrapper.OrderDetails.AddOrderDetail(newOrderDetail);
        if (result == null)
            return NotFound("Order detail not found");
        return CreatedAtAction("GetOrderDetail", orderDetail);
    }

    // DELETE: api/OrderDetails/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var result = await _serviceWrapper.OrderDetails.DeleteOrderDetail(id);
        if (!result)
            return NotFound("Order detail not found");

        return Ok("Order detail deleted");
    }
}