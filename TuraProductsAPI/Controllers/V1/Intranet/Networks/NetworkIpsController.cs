using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntranetDataAccessLibrary.Context;
using IntranetDataAccessLibrary.Models;

namespace TuraProductsAPI.Controllers.V1.Intranet.Networks
{
    [Route("api/v1/intranet/networks/[controller]")]
    [ApiController]
    public class NetworkIpsController : ControllerBase
    {
        private readonly ItturaContext _context;

        public NetworkIpsController(ItturaContext context)
        {
            _context = context;
        }

        // GET: api/NetworkIps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetworkIp>>> GetNetworkIps()
        {
          if (_context.NetworkIps == null)
          {
              return NotFound();
          }
            return await _context.NetworkIps.ToListAsync();
        }

        // GET: api/NetworkIps/5
        [HttpGet("{networkId}")]
        public async Task<ActionResult<List<NetworkIp>>> GetNetworkIp(int networkId)
        {
          if (_context.NetworkIps == null)
          {
              return NotFound();
          }
            var networkIp = await _context.NetworkIps.Where(x => x.NetworkId == networkId).ToListAsync();

            if (networkIp == null)
            {
                return NotFound();
            }

            return networkIp;
        }

        // PUT: api/NetworkIps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetworkIp(int id, NetworkIp networkIp)
        {
            if (id != networkIp.Id)
            {
                return BadRequest();
            }

            _context.Entry(networkIp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkIpExists(id))
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

        // POST: api/NetworkIps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NetworkIp>> PostNetworkIp(NetworkIp networkIp)
        {
          if (_context.NetworkIps == null)
          {
              return Problem("Entity set 'ItturaContext.NetworkIps'  is null.");
          }
            _context.NetworkIps.Add(networkIp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetworkIp", new { id = networkIp.Id }, networkIp);
        }

        // DELETE: api/NetworkIps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetworkIp(int id)
        {
            if (_context.NetworkIps == null)
            {
                return NotFound();
            }
            var networkIp = await _context.NetworkIps.FindAsync(id);
            if (networkIp == null)
            {
                return NotFound();
            }

            _context.NetworkIps.Remove(networkIp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetworkIpExists(int id)
        {
            return (_context.NetworkIps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
