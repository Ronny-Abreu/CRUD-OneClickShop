using OneClickShop.Domain.Entities;
using OneClickShop.Infrastructura.Repositories;


namespace OneClickShop.Application.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repository;

        public ProductoService(ProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }

        public async Task<Producto> ObtenerPorId(int id)
        {
            return await _repository.ObtenerPorId(id);
        }

        public async Task Agregar(Producto producto)
        {
            await _repository.Agregar(producto);
        }

        public async Task Actualizar(Producto producto)
        {
            await _repository.Actualizar(producto);
        }

        public async Task Eliminar(int id)
        {
            await _repository.Eliminar(id);
        }
    }
}
