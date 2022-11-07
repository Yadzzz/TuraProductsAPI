using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Context;
using DataAccessLibrary.Models;
using TuraProductsAPI.Attributes;

namespace TuraProductsAPI.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class TiLitProductDescriptionsController : ControllerBase
    {
        private readonly TIDataDbContext _context;

        public TiLitProductDescriptionsController(TIDataDbContext context)
        {
            _context = context;
        }

        // GET: api/TiLitProductDescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiLitProductDescription>>> GetTiLitProductDescriptions()
        {
            return await _context.TiLitProductDescriptions.ToListAsync();
        }

        // GET: api/TiLitProductDescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiLitProductDescription>> GetTiLitProductDescription(string id)
        {
            var tiLitProductDescription = await _context.TiLitProductDescriptions.FindAsync(id);

            if (tiLitProductDescription == null)
            {
                return NotFound();
            }

            return tiLitProductDescription;
        }

        // PUT: api/TiLitProductDescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiLitProductDescription(string id, TiLitProductDescription tiLitProductDescription)
        {
            if (id != tiLitProductDescription.VariantId)
            {
                return BadRequest();
            }

            _context.Entry(tiLitProductDescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiLitProductDescriptionExists(id))
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

        // POST: api/TiLitProductDescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiLitProductDescription>> PostTiLitProductDescription(TiLitProductDescription tiLitProductDescription)
        {
            _context.TiLitProductDescriptions.Add(tiLitProductDescription);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiLitProductDescriptionExists(tiLitProductDescription.VariantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiLitProductDescription", new { id = tiLitProductDescription.VariantId }, tiLitProductDescription);
        }

        // DELETE: api/TiLitProductDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiLitProductDescription(string id)
        {
            var tiLitProductDescription = await _context.TiLitProductDescriptions.FindAsync(id);
            if (tiLitProductDescription == null)
            {
                return NotFound();
            }

            _context.TiLitProductDescriptions.Remove(tiLitProductDescription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiLitProductDescriptionExists(string id)
        {
            return _context.TiLitProductDescriptions.Any(e => e.VariantId == id);
        }
    }
}
