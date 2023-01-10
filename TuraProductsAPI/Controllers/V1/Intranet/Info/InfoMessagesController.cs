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

namespace TuraProductsAPI.Controllers.V1.Intranet
{
    [ApiKey]
    [Route("api/v1/intranet/[controller]")]
    [ApiController]
    public class InfoMessagesController : ControllerBase
    {
        private readonly ItturaContext _context;

        public InfoMessagesController(ItturaContext context)
        {
            _context = context;
        }

        // GET: api/InfoMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoMessage>>> GetInfoMessages()
        {
          if (_context.InfoMessages == null)
          {
              return NotFound();
          }
            return await _context.InfoMessages.ToListAsync();
        }

        // GET: api/InfoMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoMessage>> GetInfoMessage(int id)
        {
          if (_context.InfoMessages == null)
          {
              return NotFound();
          }
            var infoMessage = await _context.InfoMessages.FindAsync(id);

            if (infoMessage == null)
            {
                return NotFound();
            }

            return infoMessage;
        }

        // PUT: api/InfoMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoMessage(int id, InfoMessage infoMessage)
        {
            if (id != infoMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoMessageExists(id))
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

        // POST: api/InfoMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoMessage>> PostInfoMessage(InfoMessage infoMessage)
        {
          if (_context.InfoMessages == null)
          {
              return Problem("Entity set 'ItturaContext.InfoMessages'  is null.");
          }
            _context.InfoMessages.Add(infoMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoMessage", new { id = infoMessage.Id }, infoMessage);
        }

        // DELETE: api/InfoMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoMessage(int id)
        {
            if (_context.InfoMessages == null)
            {
                return NotFound();
            }
            var infoMessage = await _context.InfoMessages.FindAsync(id);
            if (infoMessage == null)
            {
                return NotFound();
            }

            _context.InfoMessages.Remove(infoMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoMessageExists(int id)
        {
            return (_context.InfoMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
