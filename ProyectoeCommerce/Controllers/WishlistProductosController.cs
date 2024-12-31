using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class WishlistProductosController : ControllerBase
    {
        private readonly eCommerceContext _context;

        public WishlistProductosController(eCommerceContext context)
        {
            _context = context;
        }

        // GET: api/WishlistProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistProducto>>> GetWishlistProductos()
        {
            return await _context.WishlistProductos
                                .Include(wp => wp.Producto)
                                .Include(wp => wp.Wishlist)
                                .ToListAsync();
        }

        // GET: api/WishlistProductoes/5
        [HttpGet("{wishlistId}/{productoId}")]
        public async Task<ActionResult<WishlistProducto>> GetWishlistProducto(int wishlistId, int productoId)
        {
            var wishlistProducto = await _context.WishlistProductos.Include(wp => wp.Producto)
                .Include(wp => wp.Wishlist)
                .FirstOrDefaultAsync(wp => wp.WishlistId == wishlistId && wp.ProductoId == productoId);

            if (wishlistProducto == null)
            {
                return NotFound();
            }

            return wishlistProducto;
        }

        // PUT: api/WishlistProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{wishlistId}/{productoId}")]
        public async Task<IActionResult> PutWishlistProducto(int productoId, int wishlistId, [FromBody] WishlistProductoUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("datos inválidos");
            }

            var wishlistProducto = await _context.WishlistProductos
                        .FirstOrDefaultAsync(wp => wp.ProductoId == productoId && wp.WishlistId == wishlistId);

            if (wishlistProducto == null)
            {
                return NotFound($"No se encontró la relación Producto-Wishlist con ProductoId {productoId} y WishlistId {wishlistId}.");
            }

            
            wishlistProducto.Nombre = dto.Nombre ?? wishlistProducto.Nombre;
            wishlistProducto.FechaProductoAgregado = dto.FechaProductoAgregado;

            
            try
            {
                _context.WishlistProductos.Update(wishlistProducto);
                await _context.SaveChangesAsync();
                return NoContent(); 
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar el recurso: {ex.Message}");
            }
        }

        // POST: api/WishlistProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WishlistProducto>> PostWishlistProducto(WishlistProductoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("datos inválidos");
            }
            var productoExistente = await _context.Productos.FindAsync(dto.ProductoId);
            if (productoExistente == null)
            {
                return NotFound($"no se encontró el producto con ID{dto.ProductoId}.");
            }
            var wishlistExistente = await _context.Wishlists.FindAsync(dto.WishlistId);
            if (wishlistExistente == null)
            {
                return NotFound($"no se encontró la wishlist con ID{dto.WishlistId}.");
            }
            var wishlistProducto = new WishlistProducto
            {
                ProductoId = dto.ProductoId,
                WishlistId = dto.WishlistId,
                Nombre = dto.Nombre,
                FechaCreacion = DateTime.UtcNow,
                FechaProductoAgregado = dto.FechaProductoAgregado
            };

            _context.WishlistProductos.Add(wishlistProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWishlistProducto), new { productoId = wishlistProducto.ProductoId, wishlistId = wishlistProducto.WishlistId }, wishlistProducto);
        }

        // DELETE: api/WishlistProductoes/5
        [HttpDelete("{productoId}/{wishlistId}")]
        public async Task<IActionResult> DeleteWishlistProducto(int productoId, int wishlistId)
        {
            var wishlistProducto = await _context.WishlistProductos.FirstOrDefaultAsync(wp => wp.ProductoId == productoId && wp.WishlistId == wishlistId);
            if (wishlistProducto == null)
            {
                return NotFound("no se encontró el elemento wishlistProducto");
            }

            _context.WishlistProductos.Remove(wishlistProducto);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    mensaje="el producto ha sido eliminado",
                    status=200
                }); 
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al eliminar el recurso: {ex.Message}");
            }
        }

        private bool WishlistProductoExists(int id)
        {
            return _context.WishlistProductos.Any(e => e.ProductoId == id);
        }
    }
}
