using OneClickShop.Application.Services;
using OneClickShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class ProductoControllers : ControllerBase
{
    private readonly ProductoService _service;

    public ProductoControllers(ProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Producto>>> GetProductos()
    {
        return await _service.ObtenerTodos();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _service.ObtenerPorId(id);
        return producto == null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> PostProducto(Producto producto)
    {
        await _service.Agregar(producto);
        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        if (id != producto.Id) return BadRequest();
        await _service.Actualizar(producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        await _service.Eliminar(id);
        return NoContent();
    }
}
