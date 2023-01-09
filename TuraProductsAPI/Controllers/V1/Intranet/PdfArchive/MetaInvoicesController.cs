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
    public class MetaInvoicesController : ControllerBase
    {
        private readonly StrsTuraArchiveNewContext _context;

        public MetaInvoicesController(StrsTuraArchiveNewContext context)
        {
            _context = context;
        }

        // GET: api/MetaInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaInvoice>>> GetMetaInvoices()
        {
          if (_context.MetaInvoices == null)
          {
              return NotFound();
          }
            return await _context.MetaInvoices.ToListAsync();
        }

        // GET: api/MetaInvoices/5
        [HttpGet("getdocument/{invoiceNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaInvoice>>> GetMetaInvoice(string invoiceNumber, DateTime from, DateTime to)
        {
          if (_context.MetaInvoices == null)
          {
              return NotFound();
          }
            var metaInvoice = await _context.MetaInvoices.Where(x => x.InvoiceNumber == invoiceNumber && (x.InvoiceDate >= from && x.InvoiceDate < to)).ToListAsync();

            if (metaInvoice == null)
            {
                return NotFound();
            }

            return metaInvoice;
        }

        // GET: api/MetaInvoices/5
        [HttpGet("getdocuments/{customerNumber}/{from}/{to}")]
        public async Task<ActionResult<List<MetaInvoice>>> GetMetaInvoices(string customerNumber, DateTime from, DateTime to)
        {
            if (_context.MetaInvoices == null)
            {
                return NotFound();
            }
            var metaInvoices = await _context.MetaInvoices.Where(x => x.CustomerNumber == customerNumber && (x.InvoiceDate >= from && x.InvoiceDate < to)).ToListAsync();

            if (metaInvoices == null)
            {
                return NotFound();
            }

            return metaInvoices;
        }

        // PUT: api/MetaInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetaInvoice(Guid id, MetaInvoice metaInvoice)
        {
            if (id != metaInvoice.PartPartId)
            {
                return BadRequest();
            }

            _context.Entry(metaInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaInvoiceExists(id))
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

        // POST: api/MetaInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetaInvoice>> PostMetaInvoice(MetaInvoice metaInvoice)
        {
          if (_context.MetaInvoices == null)
          {
              return Problem("Entity set 'StrsTuraArchiveNewContext.MetaInvoices'  is null.");
          }
            _context.MetaInvoices.Add(metaInvoice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MetaInvoiceExists(metaInvoice.PartPartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMetaInvoice", new { id = metaInvoice.PartPartId }, metaInvoice);
        }

        // DELETE: api/MetaInvoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetaInvoice(Guid id)
        {
            if (_context.MetaInvoices == null)
            {
                return NotFound();
            }
            var metaInvoice = await _context.MetaInvoices.FindAsync(id);
            if (metaInvoice == null)
            {
                return NotFound();
            }

            _context.MetaInvoices.Remove(metaInvoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaInvoiceExists(Guid id)
        {
            return (_context.MetaInvoices?.Any(e => e.PartPartId == id)).GetValueOrDefault();
        }
    }
}
