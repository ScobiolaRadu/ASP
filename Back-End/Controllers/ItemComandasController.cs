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
    public class ItemComandasController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemComandasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ItemComandas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemComanda>>> GetitemComandas()
        {
          if (_context.itemComandas == null)
          {
              return NotFound();
          }
            return await _context.itemComandas.ToListAsync();
        }

        // GET: api/ItemComandas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemComanda>> GetItemComanda(int id)
        {
          if (_context.itemComandas == null)
          {
              return NotFound();
          }
            var itemComanda = await _context.itemComandas.FindAsync(id);

            if (itemComanda == null)
            {
                return NotFound();
            }

            return itemComanda;
        }

        // PUT: api/ItemComandas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemComanda(int id, ItemComanda itemComanda)
        {
            if (id != itemComanda.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemComanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemComandaExists(id))
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

        // POST: api/ItemComandas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemComanda>> PostItemComanda(ItemComanda itemComanda)
        {
          if (_context.itemComandas == null)
          {
              return Problem("Entity set 'DataContext.itemComandas'  is null.");
          }
            _context.itemComandas.Add(itemComanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemComanda", new { id = itemComanda.Id }, itemComanda);
        }

        // DELETE: api/ItemComandas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemComanda(int id)
        {
            if (_context.itemComandas == null)
            {
                return NotFound();
            }
            var itemComanda = await _context.itemComandas.FindAsync(id);
            if (itemComanda == null)
            {
                return NotFound();
            }

            _context.itemComandas.Remove(itemComanda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemComandaExists(int id)
        {
            return (_context.itemComandas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
