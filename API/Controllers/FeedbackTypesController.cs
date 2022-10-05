using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Domain.EntitiesForManagement;

namespace net6API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FeedbackTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackType>>> GetFeedbackTypes()
        {
            return await _context.FeedbackTypes.ToListAsync();
        }

        // GET: api/FeedbackTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackType>> GetFeedbackType(int id)
        {
            var feedbackType = await _context.FeedbackTypes.FindAsync(id);

            if (feedbackType == null)
            {
                return NotFound();
            }

            return feedbackType;
        }

        // PUT: api/FeedbackTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackType(int id, FeedbackType feedbackType)
        {
            if (id != feedbackType.FeedbackTypeId)
            {
                return BadRequest();
            }

            _context.Entry(feedbackType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FeedbackTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackType>> PostFeedbackType(FeedbackType feedbackType)
        {
            _context.FeedbackTypes.Add(feedbackType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackType", new { id = feedbackType.FeedbackTypeId }, feedbackType);
        }

        // DELETE: api/FeedbackTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackType(int id)
        {
            var feedbackType = await _context.FeedbackTypes.FindAsync(id);
            if (feedbackType == null)
            {
                return NotFound();
            }

            _context.FeedbackTypes.Remove(feedbackType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackTypeExists(int id)
        {
            return _context.FeedbackTypes.Any(e => e.FeedbackTypeId == id);
        }
    }
}
