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
    public class MetaReturordersController : ControllerBase
    {
        private readonly StrsTuraArchiveNewContext _context;

        public MetaReturordersController(StrsTuraArchiveNewContext context)
        {
            _context = context;
        }

        // GET: api/MetaReturorders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaReturorder>>> GetMetaReturorders()
        {
          if (_context.MetaReturorders == null)
          {
              return NotFound();
          }
            return await _context.MetaReturorders.ToListAsync();
        }

        // GET: api/MetaReturorders/5
        [HttpGet("getdocument/{orderNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaReturorder>>> GetMetaReturorder(string orderNumber, DateTime from, DateTime to)
        {
          if (_context.MetaReturorders == null)
          {
              return NotFound();
          }
            var metaReturorder = await _context.MetaReturorders.Where(x => x.OrderNumber == orderNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaReturorder == null)
            {
                return NotFound();
            }

            return metaReturorder;
        }

        // GET: api/MetaReturorders/5
        [HttpGet("getdocuments/{customerNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaReturorder>>> GetMetaReturorders(string customerNumber, DateTime from, DateTime to)
        {
            if (_context.MetaReturorders == null)
            {
                return NotFound();
            }
            var metaReturorder = await _context.MetaReturorders.Where(x => x.CustomerNumber == customerNumber && (x.OrderDate >= from && x.OrderDate < to)).ToListAsync();

            if (metaReturorder == null)
            {
                return NotFound();
            }

            return metaReturorder;
        }

        // PUT: api/MetaReturorders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaReturorder(Guid id, MetaReturorder metaReturorder)
        {
            if (id != metaReturorder.PartPartId)
            {
                return BadRequest();
            }

            _context.Entry(metaReturorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaReturorderExists(id))
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

        // POST: api/MetaReturorders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaReturorder>> PostMetaReturorder(MetaReturorder metaReturorder)
        {
          if (_context.MetaReturorders == null)
          {
              return Problem("Entity set 'StrsTuraArchiveNewContext.MetaReturorders'  is null.");
          }
            _context.MetaReturorders.Add(metaReturorder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetaReturorderExists(metaReturorder.PartPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetaReturorder", new { id = metaReturorder.PartPartId }, metaReturorder);
        }

        // DELETE: api/MetaReturorders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaReturorder(Guid id)
        {
            if (_context.MetaReturorders == null)
            {
                return NotFound();
            }
            var metaReturorder = await _context.MetaReturorders.FindAsync(id);
            if (metaReturorder == null)
            {
                return NotFound();
            }

            _context.MetaReturorders.Remove(metaReturorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaReturorderExists(Guid id)
        {
            return (_context.MetaReturorders?.Any(e => e.PartPartId == id)).GetValueOrDefault();
        }
    }
}
