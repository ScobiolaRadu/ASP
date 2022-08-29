using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectOpt.Data;
using ProiectOpt.Models;

namespace ProiectOpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaClientsController : ControllerBase
    {
        private readonly DataContext _context;

        public ComandaClientsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ComandaClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComandaClient>>> GetcomandaClients()
        {
          if (_context.comandaClients == null)
          {
              return NotFound();
          }
            return await _context.comandaClients.ToListAsync();
        }

        // GET: api/ComandaClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComandaClient>> GetComandaClient(int id)
        {
          if (_context.comandaClients == null)
          {
              return NotFound();
          }
            var comandaClient = await _context.comandaClients.FindAsync(id);

            if (comandaClient == null)
            {
                return NotFound();
            }

            return comandaClient;
        }

        // PUT: api/ComandaClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComandaClient(int id, ComandaClient comandaClient)
        {
            if (id != comandaClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(comandaClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaClientExists(id))
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

        // POST: api/ComandaClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComandaClient>> PostComandaClient(ComandaClient comandaClient)
        {
          if (_context.comandaClients == null)
          {
              return Problem("Entity set 'DataContext.comandaClients'  is null.");
          }
            _context.comandaClients.Add(comandaClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComandaClient", new { id = comandaClient.Id }, comandaClient);
        }

        // DELETE: api/ComandaClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComandaClient(int id)
        {
            if (_context.comandaClients == null)
            {
                return NotFound();
            }
            var comandaClient = await _context.comandaClients.FindAsync(id);
            if (comandaClient == null)
            {
                return NotFound();
            }

            _context.comandaClients.Remove(comandaClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComandaClientExists(int id)
        {
            return (_context.comandaClients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
