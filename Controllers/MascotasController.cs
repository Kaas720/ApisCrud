using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApisCrud.Data;
using ApisCrud.Model;

namespace ApisCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly DbContextProducto _context;

        public MascotasController(DbContextProducto context)
        {
            _context = context;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascotas>>> Getmascotas()
        {
            if (_context.mascotas == null)
            {
                return NotFound();
            }
            return await _context.mascotas.ToListAsync();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascotas>> GetMascotasID(int id)
        {
            if (_context.mascotas == null)
            {
                return NotFound();
            }
            var mascotasReturn = await _context.mascotas.FindAsync(id);

            if (mascotasReturn == null)
            {
                return NotFound();
            }

            return mascotasReturn;
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascotas(int id, Mascotas mascotas)
        {
            if (id != mascotas.idMascotas)
            {
                return BadRequest();
            }

            _context.Entry(mascotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mascotas>> PostMascotas(Mascotas mascotas)
        {
            if (_context.mascotas == null)
            {
                return Problem("Entity set 'DbContextProducto.cliente'  is null.");
            }
            _context.mascotas.Add(mascotas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = mascotas.idMascotas }, mascotas);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (_context.mascotas == null)
            {
                return NotFound();
            }
            var mascotas = await _context.mascotas.FindAsync(id);
            if (mascotas == null)
            {
                return NotFound();
            }

            _context.mascotas.Remove(mascotas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return (_context.mascotas?.Any(e => e.idMascotas == id)).GetValueOrDefault();
        }
    }
}
