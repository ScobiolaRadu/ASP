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
    public class FabricantsController : ControllerBase
    {
        private readonly DataContext _context;

        public FabricantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Fabricants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricant>>> Getfabricants()
        {
          if (_context.fabricants == null)
          {
              return NotFound();
          }
            return await _context.fabricants.ToListAsync();
        }

        // GET: api/Fabricants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricant>> GetFabricant(int id)
        {
          if (_context.fabricants == null)
          {
              return NotFound();
          }
            var fabricant = await _context.fabricants.FindAsync(id);

            if (fabricant == null)
            {
                return NotFound();
            }

            return fabricant;
        }

        // PUT: api/Fabricants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricant(int id, Fabricant fabricant)
        {
            if (id != fabricant.Id)
            {
                return BadRequest();
            }

            _context.Entry(fabricant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricantExists(id))
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

        // POST: api/Fabricants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fabricant>> PostFabricant(Fabricant fabricant)
        {
          if (_context.fabricants == null)
          {
              return Problem("Entity set 'DataContext.fabricants'  is null.");
          }
            _context.fabricants.Add(fabricant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFabricant", new { id = fabricant.Id }, fabricant);
        }

        // DELETE: api/Fabricants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricant(int id)
        {
            if (_context.fabricants == null)
            {
                return NotFound();
            }
            var fabricant = await _context.fabricants.FindAsync(id);
            if (fabricant == null)
            {
                return NotFound();
            }

            _context.fabricants.Remove(fabricant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FabricantExists(int id)
        {
            return (_context.fabricants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
