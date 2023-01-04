using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntranetDataAccessLibrary.Context;
using IntranetDataAccessLibrary.Models;

namespace TuraProductsAPI.Controllers.V1.Intranet.Customers
{
    [Route("api/v1/intranet/customers/[controller]")]
    [ApiController]
    public class SpecialCustomersController : ControllerBase
    {
        private readonly ItturaContext _context;

        public SpecialCustomersController(ItturaContext context)
        {
            _context = context;
        }

        // GET: api/SpecialCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialCustomer>>> GetSpecialCustomers()
        {
          if (_context.SpecialCustomers == null)
          {
              return NotFound();
          }
            return await _context.SpecialCustomers.Where(x => x.IsDeleted == false).ToListAsync();
        }

        // GET: api/SpecialCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialCustomer>> GetSpecialCustomer(int id)
        {
          if (_context.SpecialCustomers == null)
          {
              return NotFound();
          }
            var specialCustomer = await _context.SpecialCustomers.FindAsync(id);

            if (specialCustomer == null)
            {
                return NotFound();
            }

            return specialCustomer;
        }

        // PUT: api/SpecialCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialCustomer(int id, SpecialCustomer specialCustomer)
        {
            if (id != specialCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialCustomerExists(id))
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

        // POST: api/SpecialCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialCustomer>> PostSpecialCustomer(SpecialCustomer specialCustomer)
        {
          if (_context.SpecialCustomers == null)
          {
              return Problem("Entity set 'ItturaContext.SpecialCustomers'  is null.");
          }
            _context.SpecialCustomers.Add(specialCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialCustomer", new { id = specialCustomer.Id }, specialCustomer);
        }

        // DELETE: api/SpecialCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialCustomer(int id)
        {
            if (_context.SpecialCustomers == null)
            {
                return NotFound();
            }
            var specialCustomer = await _context.SpecialCustomers.FindAsync(id);
            if (specialCustomer == null)
            {
                return NotFound();
            }

            _context.SpecialCustomers.Remove(specialCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialCustomerExists(int id)
        {
            return (_context.SpecialCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
