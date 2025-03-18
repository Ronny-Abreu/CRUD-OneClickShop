using OneClickShop.Application.Services;
using OneClickShop.Domain.Entities;
using OneClickShop.Api.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace OneClickShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var productos = await _service.ObtenerTodos();
            var productosDto = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();

            if (productosDto.Count == 0)
            {
                return NotFound(new { message = "No se encontraron productos." });
            }

            return Ok(new { message = "Productos obtenidos exitosamente.", data = productosDto });
        }

        // Obtener un producto por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var producto = await _service.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado." });
            }

            var productoDto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            return Ok(new { message = "Producto obtenido exitosamente.", data = productoDto });
        }

        // Crear un producto
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] ProductoDto productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest(new { message = "Los datos del producto no son válidos." });
            }

            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock
            };

            await _service.Agregar(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, new { message = "Producto creado exitosamente." });
        }

        // Actualizar un producto
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] ProductoDto productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest(new { message = "El ID del producto no coincide." });
            }

            var producto = new Producto
            {
                Id = productoDto.Id,
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock
            };

            await _service.Actualizar(producto);
            return Ok(new { message = "Producto actualizado exitosamente." });
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _service.Eliminar(id);
            return Ok(new { message = "Producto eliminado exitosamente." });
        }
    }
}