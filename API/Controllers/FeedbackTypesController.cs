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
public class FeedbackTypesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/FeedbackTypes
    public FeedbackTypesController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IEnumerable<FeedbackType>>> GetFeedbackTypes(
        ODataQueryOptions<FeedbackTypeGetDto>? options)
    {
        var list = _serviceWrapper.FeedbackTypes.GetFeedbackTypeList();
        if (!list.Any())
            return NotFound();

        return Ok(await list.GetQueryAsync(_mapper, options));
    }

    // GET: api/FeedbackTypes/5
    [EnableQuery]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<FeedbackType>> GetFeedbackType(int id,
        ODataQueryOptions<FeedbackTypeGetDto>? options)
    {
        var list = _serviceWrapper.Feedbacks.GetFeedbackList()
            .Where(x => x.FeedbackId == id);
        if (list.IsNullOrEmpty())
            return NotFound("Feedback type not found");
        return Ok((await list.GetQueryAsync(_mapper, options)).ToArray()[0]);
    }

    // PUT: api/FeedbackTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFeedbackType(int id, FeedbackTypeUpdateDto feedbackType)
    {
        if (id != feedbackType.FeedbackTypeId) return BadRequest();
        var updateFeedBackType = new FeedbackType
        {
            Name = feedbackType.Name,
            FeedbackTypeId = id
        };
        var result = await _serviceWrapper.FeedbackTypes.UpdateFeedbackType(updateFeedBackType);
        if (result == null)
            return NotFound("Feedback type not found");
        return Ok("Feedback type updated");
    }

    // POST: api/FeedbackTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<FeedbackType>> PostFeedbackType(FeedbackTypeCreateDto feedbackType)
    {
        var newFeedbackType = new FeedbackType
        {
            Name = feedbackType.Name
        };
        var result = await _serviceWrapper.FeedbackTypes.AddFeedbackType(newFeedbackType);
        if (result == null)
            return NotFound("Feedback type not found");
        return CreatedAtAction("GetFeedbackType", new { id = feedbackType.FeedbackTypeId }, feedbackType);
    }

    // DELETE: api/FeedbackTypes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFeedbackType(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound("Feedback type not found");
        return Ok("Feedback type deleted");
    }
}