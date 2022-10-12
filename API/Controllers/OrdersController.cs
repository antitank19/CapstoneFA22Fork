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
public class OrdersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    public OrdersController(IServiceWrapper serviceWrapper, IMapper mapper)
    {
        _serviceWrapper = serviceWrapper;
        _mapper = mapper;
    }

    // GET: api/Orders
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders(ODataQueryOptions<OrderGetDto>? options)
    {
        var list = _serviceWrapper.Orders.GetOrderList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/Orders/5
    [HttpGet("{id:int}")]
    [EnableQuery]
    public async Task<ActionResult<Order>> GetOrder(int id, ODataQueryOptions<OrderGetDto>? options)
    {
        var list = _serviceWrapper.Orders.GetOrderList()
            .Where(x => x.OrderId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Order not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/Orders/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutOrder(int id, OrderUpdateDto order)
    {
        if (id != order.OrderId) return BadRequest();
        var updateOrder = new Order
        {
            OrderId = id,
            Name = order.Name,
            Status = order.Status,
            RenterId = order.RenterId,
            RequestId = order.RequestId
            // TODO: Check request ID if match
        };

        var result = await _serviceWrapper.Orders.UpdateOrder(updateOrder);
        if (result == null)
            return NotFound("Request type not found");

        return Ok("Request type updated successfully");
    }

    // POST: api/Orders
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(OrderGetDto order)
    {
        var newOrder = new Order
        {
            Name = order.Name,
            Status = order.Status,
            RenterId = order.RenterId,
            RequestId = order.RequestId
        };
        var result = await _serviceWrapper.Orders.AddOrder(newOrder);
        if (result == null)
            return NotFound("Request type not found");
        return CreatedAtAction("GetOrder", order);
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var result = await _serviceWrapper.Orders.DeleteOrder(id);
        if (!result)
            return NotFound("Order not found");

        return Ok("Order deleted");
    }
}