﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectOpt.Auth;
using ProiectOpt.Data;
using ProiectOpt.Interfaces;
using ProiectOpt.Models;

namespace ProiectOpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(DataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> Getcategories()
        {
          if (_context.categories == null)
          {
              return NotFound();
          }
            return await _context.categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
          if (_context.categories == null)
          {
              return NotFound();
          }
            var categorie = await _context.categories.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Categorie> GetInstrumenteCuCorzi()
        {
            return unitOfWork.Categorie.GetInstrumenteCuCorzi();
        }


        [Authorize(Roles = UserRoles.Admin)]
        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        [Authorize(Roles = UserRoles.Admin)]
        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {
          if (_context.categories == null)
          {
              return Problem("Entity set 'DataContext.categories'  is null.");
          }
            _context.categories.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie", new { id = categorie.Id }, categorie);
        }

        [Authorize(Roles = UserRoles.Admin)]
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            if (_context.categories == null)
            {
                return NotFound();
            }
            var categorie = await _context.categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.categories.Remove(categorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieExists(int id)
        {
            return (_context.categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
