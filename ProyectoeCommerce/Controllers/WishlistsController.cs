using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoeCommerce;
using ProyectoeCommerce.DTOs;
using ProyectoeCommerce.Models.Entity;

namespace ProyectoeCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly eCommerceContext _context;

        public WishlistsController(eCommerceContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlists()
        {
            return await _context.Wishlists
                .Include(w=>w.Usuario)
                .Include(w=>w.WishlistProductos)
                .ToListAsync();
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            var wishlist = await _context.Wishlists
                .Include(w => w.Usuario)
                .Include(w => w.WishlistProductos)
                .ThenInclude(wp => wp.Producto)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (wishlist == null)
                return NotFound(new { message = $"Wishlist con ID {id} no encontrada." });

            return wishlist;
        }

        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, WishlistDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del DTO.");
            }

            var existingWishlist = await _context.Wishlists.FindAsync(id);

            if (existingWishlist == null)
            {
                return NotFound("La wishlist no fue encontrada.");
            }

            // Actualizar las propiedades de la wishlist
            existingWishlist.Nombre = dto.Nombre;
            existingWishlist.UsuarioId = dto.UsuarioId;

            try
            {
                _context.Wishlists.Update(existingWishlist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al actualizar la wishlist en la base de datos.");
            }

            return Ok("Wishlist actualizada exitosamente.");
        }

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(WishlistDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _context.Usuarios.FindAsync(dto.UsuarioId);
            if (usuario == null)
            {
                return NotFound("El usuario especificado no existe.");
            }

            var newWishlist = new Wishlist
            {
                Nombre = dto.Nombre,
                UsuarioId = dto.UsuarioId
            };

            try
            {
                _context.Wishlists.Add(newWishlist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al crear la wishlist en la base de datos.");
            }

            return CreatedAtAction(nameof(GetWishlist), new { id = newWishlist.Id }, newWishlist);
        }
        /*
        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishlistExists(int id)
        {
            return _context.Wishlists.Any(e => e.Id == id);
        }
         */
    }
}
