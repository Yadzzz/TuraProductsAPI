using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamServiceDataAccessLibrary.Context;
using StreamServiceDataAccessLibrary.Models;
using TuraProductsAPI.Attributes;

namespace TuraProductsAPI.Controllers.V1.Intranet.PdfArchive
{
    [ApiKey]
    [Route("api/v1/intranet/pdfarchive/[controller]")]
    [ApiController]
    public class MetaOrderbeksController : ControllerBase
    {
        private readonly StrsTuraArchiveNewContext _context;

        public MetaOrderbeksController(StrsTuraArchiveNewContext context)
        {
            _context = context;
        }

        // GET: api/MetaOrderbeks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaOrderbek>>> GetMetaOrderbeks()
        {
          if (_context.MetaOrderbeks == null)
          {
              return NotFound();
          }
            return await _context.MetaOrderbeks.ToListAsync();
        }

        // GET: api/MetaOrderbeks/5
        [HttpGet("getdocument/{orderNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaOrderbek>>> GetMetaOrderbek(string orderNumber, DateTime from, DateTime to)
        {
          if (_context.MetaOrderbeks == null)
          {
              return NotFound();
          }
            var metaOrderbek = await _context.MetaOrderbeks.Where(x => x.OrderNumber == orderNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaOrderbek == null)
            {
                return NotFound();
            }

            return metaOrderbek;
        }

        // GET: api/MetaOrderbeks/5
        [HttpGet("getdocuments/{customerNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaOrderbek>>> GetMetaOrderbeks(string customerNumber, DateTime from, DateTime to)
        {
            if (_context.MetaOrderbeks == null)
            {
                return NotFound();
            }
            var metaOrderbek = await _context.MetaOrderbeks.Where(x => x.CustomerNumber == customerNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaOrderbek == null)
            {
                return NotFound();
            }

            return metaOrderbek;
        }

        // PUT: api/MetaOrderbeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaOrderbek(Guid id, MetaOrderbek metaOrderbek)
        {
            if (id != metaOrderbek.PartPartId)
            {
                return BadRequest();
            }

            _context.Entry(metaOrderbek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaOrderbekExists(id))
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

        // POST: api/MetaOrderbeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaOrderbek>> PostMetaOrderbek(MetaOrderbek metaOrderbek)
        {
          if (_context.MetaOrderbeks == null)
          {
              return Problem("Entity set 'StrsTuraArchiveNewContext.MetaOrderbeks'  is null.");
          }
            _context.MetaOrderbeks.Add(metaOrderbek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetaOrderbekExists(metaOrderbek.PartPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetaOrderbek", new { id = metaOrderbek.PartPartId }, metaOrderbek);
        }

        // DELETE: api/MetaOrderbeks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaOrderbek(Guid id)
        {
            if (_context.MetaOrderbeks == null)
            {
                return NotFound();
            }
            var metaOrderbek = await _context.MetaOrderbeks.FindAsync(id);
            if (metaOrderbek == null)
            {
                return NotFound();
            }

            _context.MetaOrderbeks.Remove(metaOrderbek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaOrderbekExists(Guid id)
        {
            return (_context.MetaOrderbeks?.Any(e => e.PartPartId == id)).GetValueOrDefault();
        }
    }
}
