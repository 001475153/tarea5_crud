using MiAppCrud.Models;
using MiAppCrud.Services;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAppCrud.Controllers
{
    public class ProductoController
    {
        private readonly ProductoService _productoService;
        public ProductoController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _productoService = new ProductoService(dbPath);
        }
        public Task<List<Producto>> GetAllProductos()
        {
            return _productoService.GetAll();
        }

        public void AddProducto(Producto producto)
        {
            _productoService.Add(producto);
        }

        public void UpdateProducto(Producto producto)
        {
            _productoService.Update(producto);
        }
        public void DeleteProducto(int id)
        {
            _productoService.Delete(id);
        }
    }
}