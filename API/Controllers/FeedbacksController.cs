﻿using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Service.IService;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IServiceWrapper _serviceWrapper;

    // GET: api/Feedbacks
    public FeedbacksController(IMapper mapper, IServiceWrapper serviceWrapper)
    {
        _mapper = mapper;
        _serviceWrapper = serviceWrapper;
    }

    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<Feedback>> GetFeedbacks(ODataQueryOptions<AccountGetDto>? options)
    {
    }

    // GET: api/Feedbacks/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Feedback>> GetFeedback(int id)
    {
    }

    // PUT: api/Feedbacks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutFeedback(int id, FeedbackUpdateDto feedback)
    {
        if (id != feedback.FeedbackId)
            return BadRequest();

        var updateFeedback = new Feedback
        {
            FeedbackId = id,
            FeedbackTypeId = feedback.FeedbackTypeId,
            Description = feedback.Description,
            FlatId = feedback.RenterId
        };

        var result = await _serviceWrapper.Feedbacks.UpdateFeedback(updateFeedback);
        if (result == null)
            return NotFound();

        return Ok();
    }


    // POST: api/Feedbacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Feedback>> PostFeedback(FeedbackCreateDto feedback)
    {
        var addNewFeedback = new Feedback
        {
            FeedbackTypeId = feedback.FeedbackTypeId,
            Description = feedback.Description,
            Status = Enum.GetName(typeof(StatusEnum), StatusEnum.Pending),
            CreateDate = DateTime.Now,
            FlatId = feedback.RenterId
        };

        var result = await _serviceWrapper.Feedbacks.AddFeedback(addNewFeedback);
        if (result == null)
            return BadRequest();

        return CreatedAtAction("GetFeedback", new { id = result.FeedbackId }, result);
    }

    // DELETE: api/Feedbacks/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteFeedback(int id)
    {
        var result = await _serviceWrapper.Feedbacks.DeleteFeedback(id);
        if (!result)
            return NotFound("Feedback not found");

        return Ok("Feedback deleted");
    }
}