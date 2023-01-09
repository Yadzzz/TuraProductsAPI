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
    public class MetaFinanceChrgsController : ControllerBase
    {
        private readonly StrsTuraArchiveNewContext _context;

        public MetaFinanceChrgsController(StrsTuraArchiveNewContext context)
        {
            _context = context;
        }

        // GET: api/MetaFinanceChrgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaFinanceChrg>>> GetMetaFinanceChrgs()
        {
          if (_context.MetaFinanceChrgs == null)
          {
              return NotFound();
          }
            return await _context.MetaFinanceChrgs.ToListAsync();
        }

        // GET: api/MetaFinanceChrgs/5
        [HttpGet("getdocument/{invoiceNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaFinanceChrg>>> GetMetaFinanceChrg(string invoiceNumber, DateTime from, DateTime to)
        {
          if (_context.MetaFinanceChrgs == null)
          {
              return NotFound();
          }
            var metaFinanceChrg = await _context.MetaFinanceChrgs.Where(x => x.InvoiceNumber == invoiceNumber && (x.InvoiceDate >= from && x.InvoiceDate < to)).ToListAsync();

            if (metaFinanceChrg == null)
            {
                return NotFound();
            }

            return metaFinanceChrg;
        }

        // GET: api/MetaFinanceChrgs/5
        [HttpGet("getdocuments/{invoiceNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaFinanceChrg>>> GetMetaFinanceChrgs(string customerNumber, DateTime from, DateTime to)
        {
            if (_context.MetaFinanceChrgs == null)
            {
                return NotFound();
            }
            var metaFinanceChrg = await _context.MetaFinanceChrgs.Where(x => x.CustomerNumber == customerNumber && (x.InvoiceDate >= from && x.InvoiceDate < to)).ToListAsync();

            if (metaFinanceChrg == null)
            {
                return NotFound();
            }

            return metaFinanceChrg;
        }

        // PUT: api/MetaFinanceChrgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaFinanceChrg(Guid id, MetaFinanceChrg metaFinanceChrg)
        {
            if (id != metaFinanceChrg.PartPartId)
            {
                return BadRequest();
            }

            _context.Entry(metaFinanceChrg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaFinanceChrgExists(id))
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

        // POST: api/MetaFinanceChrgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaFinanceChrg>> PostMetaFinanceChrg(MetaFinanceChrg metaFinanceChrg)
        {
          if (_context.MetaFinanceChrgs == null)
          {
              return Problem("Entity set 'StrsTuraArchiveNewContext.MetaFinanceChrgs'  is null.");
          }
            _context.MetaFinanceChrgs.Add(metaFinanceChrg);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetaFinanceChrgExists(metaFinanceChrg.PartPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetaFinanceChrg", new { id = metaFinanceChrg.PartPartId }, metaFinanceChrg);
        }

        // DELETE: api/MetaFinanceChrgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaFinanceChrg(Guid id)
        {
            if (_context.MetaFinanceChrgs == null)
            {
                return NotFound();
            }
            var metaFinanceChrg = await _context.MetaFinanceChrgs.FindAsync(id);
            if (metaFinanceChrg == null)
            {
                return NotFound();
            }

            _context.MetaFinanceChrgs.Remove(metaFinanceChrg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaFinanceChrgExists(Guid id)
        {
            return (_context.MetaFinanceChrgs?.Any(e => e.PartPartId == id)).GetValueOrDefault();
        }
    }
}
