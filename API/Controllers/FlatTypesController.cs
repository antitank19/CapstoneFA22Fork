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
    public class FlatTypesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FlatTypesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/FlatTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlatType>>> GetFlatTypes()
        {
            return await _context.FlatTypes.ToListAsync();
        }

        // GET: api/FlatTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatType>> GetFlatType(int id)
        {
            var flatType = await _context.FlatTypes.FindAsync(id);

            if (flatType == null)
            {
                return NotFound();
            }

            return flatType;
        }

        // PUT: api/FlatTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlatType(int id, FlatType flatType)
        {
            if (id != flatType.FlatTypeId)
            {
                return BadRequest();
            }

            _context.Entry(flatType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatTypeExists(id))
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

        // POST: api/FlatTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlatType>> PostFlatType(FlatType flatType)
        {
            _context.FlatTypes.Add(flatType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlatType", new { id = flatType.FlatTypeId }, flatType);
        }

        // DELETE: api/FlatTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlatType(int id)
        {
            var flatType = await _context.FlatTypes.FindAsync(id);
            if (flatType == null)
            {
                return NotFound();
            }

            _context.FlatTypes.Remove(flatType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlatTypeExists(int id)
        {
            return _context.FlatTypes.Any(e => e.FlatTypeId == id);
        }
    }
}
