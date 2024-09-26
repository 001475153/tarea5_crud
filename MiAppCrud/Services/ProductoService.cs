using MiAppCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAppCrud.Services
{
    public class ProductoService
    {
        private readonly Database _database;

        public ProductoService(string dbPath)
        {
            _database = new Database(dbPath);
        }

        public Task<List<Producto>> GetAll() => _database.GetAllProductosAsync();

        public Task Add(Producto producto) => _database.SaveProductoAsync(producto);

        public Task Update(Producto producto) => _database.SaveProductoAsync(producto);

        public Task Delete(int id) => _database.DeleteProductoAsync(id);
    }
}

