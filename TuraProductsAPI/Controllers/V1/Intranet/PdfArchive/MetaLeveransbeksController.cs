using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamServiceDataAccessLibrary.Context;
using StreamServiceDataAccessLibrary.Models;

namespace TuraProductsAPI.Controllers.V1.Intranet.PdfArchive
{
    [Route("api/v1/intranet/pdfarchive/[controller]")]
    [ApiController]
    public class MetaLeveransbeksController : ControllerBase
    {
        private readonly StrsTuraArchiveNewContext _context;

        public MetaLeveransbeksController(StrsTuraArchiveNewContext context)
        {
            _context = context;
        }

        // GET: api/MetaLeveransbeks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaLeveransbek>>> GetMetaLeveransbeks()
        {
          if (_context.MetaLeveransbeks == null)
          {
              return NotFound();
          }
            return await _context.MetaLeveransbeks.ToListAsync();
        }

        // GET: api/MetaLeveransbeks/5
        [HttpGet("getdocument/{orderNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaLeveransbek>>> GetMetaLeveransbek(string orderNumber, DateTime from, DateTime to)
        {
          if (_context.MetaLeveransbeks == null)
          {
              return NotFound();
          }
            var metaLeveransbek = await _context.MetaLeveransbeks.Where(x => x.OrderNumber == orderNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaLeveransbek == null)
            {
                return NotFound();
            }

            return metaLeveransbek;
        }

        // GET: api/MetaLeveransbeks/5
        [HttpGet("getdocuments/{customerNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaLeveransbek>>> GetMetaLeveransbeks(string customerNumber, DateTime from, DateTime to)
        {
            if (_context.MetaLeveransbeks == null)
            {
                return NotFound();
            }
            var metaLeveransbek = await _context.MetaLeveransbeks.Where(x => x.CustomerNumber == customerNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaLeveransbek == null)
            {
                return NotFound();
            }

            return metaLeveransbek;
        }

        // PUT: api/MetaLeveransbeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaLeveransbek(Guid id, MetaLeveransbek metaLeveransbek)
        {
            if (id != metaLeveransbek.PartPartId)
            {
                return BadRequest();
            }

            _context.Entry(metaLeveransbek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaLeveransbekExists(id))
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

        // POST: api/MetaLeveransbeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaLeveransbek>> PostMetaLeveransbek(MetaLeveransbek metaLeveransbek)
        {
          if (_context.MetaLeveransbeks == null)
          {
              return Problem("Entity set 'StrsTuraArchiveNewContext.MetaLeveransbeks'  is null.");
          }
            _context.MetaLeveransbeks.Add(metaLeveransbek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetaLeveransbekExists(metaLeveransbek.PartPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetaLeveransbek", new { id = metaLeveransbek.PartPartId }, metaLeveransbek);
        }

        // DELETE: api/MetaLeveransbeks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaLeveransbek(Guid id)
        {
            if (_context.MetaLeveransbeks == null)
            {
                return NotFound();
            }
            var metaLeveransbek = await _context.MetaLeveransbeks.FindAsync(id);
            if (metaLeveransbek == null)
            {
                return NotFound();
            }

            _context.MetaLeveransbeks.Remove(metaLeveransbek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaLeveransbekExists(Guid id)
        {
            return (_context.MetaLeveransbeks?.Any(e => e.PartPartId == id)).GetValueOrDefault();
        }
    }
}
