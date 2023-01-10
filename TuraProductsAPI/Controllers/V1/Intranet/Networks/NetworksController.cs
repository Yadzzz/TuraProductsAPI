using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntranetDataAccessLibrary.Context;
using IntranetDataAccessLibrary.Models;
using TuraProductsAPI.Attributes;

namespace TuraProductsAPI.Controllers.V1.Intranet.Networks
{
    [ApiKey]
    [Route("api/v1/intranet/networks/[controller]")]
    [ApiController]
    public class NetworksController : ControllerBase
    {
        private readonly ItturaContext _context;

        public NetworksController(ItturaContext context)
        {
            _context = context;
        }

        // GET: api/Networks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Network>>> GetNetworks()
        {
          if (_context.Networks == null)
          {
              return NotFound();
          }
            return await _context.Networks.ToListAsync();
        }

        // GET: api/Networks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Network>> GetNetwork(int id)
        {
          if (_context.Networks == null)
          {
              return NotFound();
          }
            var network = await _context.Networks.FindAsync(id);

            if (network == null)
            {
                return NotFound();
            }

            return network;
        }

        // PUT: api/Networks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetwork(int id, Network network)
        {
            if (id != network.Id)
            {
                return BadRequest();
            }

            _context.Entry(network).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkExists(id))
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

        // POST: api/Networks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Network>> PostNetwork(Network network)
        {
          if (_context.Networks == null)
          {
              return Problem("Entity set 'ItturaContext.Networks'  is null.");
          }
            _context.Networks.Add(network);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetwork", new { id = network.Id }, network);
        }

        // DELETE: api/Networks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetwork(int id)
        {
            if (_context.Networks == null)
            {
                return NotFound();
            }
            var network = await _context.Networks.FindAsync(id);
            if (network == null)
            {
                return NotFound();
            }

            _context.Networks.Remove(network);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetworkExists(int id)
        {
            return (_context.Networks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
