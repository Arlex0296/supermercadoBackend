using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermercadoAPI.Models;

namespace SupermercadoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var productos = await _context.Productos.ToListAsync();

                if (productos == null || productos.Count == 0)
                {
                    return NotFound("No hay productos disponibles.");
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductos), new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar el producto: {ex.Message}");
            }
        }
    }
}
