using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiAppCrud.Models;

namespace MiAppCrud.Services
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();

            _database.CreateTableAsync<Proveedor>().Wait();  // Agregamos la tabla Proveedor
            _database.CreateTableAsync<Orden>().Wait();      // Agregamos la tabla Orden
        }

        // Métodos CRUD para Producto
        public Task<List<Producto>> GetAllProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<Producto> GetProductoAsync(int id) => _database.Table<Producto>().FirstOrDefaultAsync(p => p.Id == id);
        public Task<int> SaveProductoAsync(Producto producto) => producto.Id != 0 ? _database.UpdateAsync(producto) : _database.InsertAsync(producto);
        public Task<int> DeleteProductoAsync(int id) => _database.DeleteAsync<Producto>(id);

        // Métodos CRUD para Categoria
        public Task<List<Categoria>> GetAllCategoriasAsync() => _database.Table<Categoria>().ToListAsync();
        public Task<Categoria> GetCategoriaAsync(int id) => _database.Table<Categoria>().FirstOrDefaultAsync(c => c.Id == id);
        public Task<int> SaveCategoriaAsync(Categoria categoria) => categoria.Id != 0 ? _database.UpdateAsync(categoria) : _database.InsertAsync(categoria);
        public Task<int> DeleteCategoriaAsync(int id) => _database.DeleteAsync<Categoria>(id);

        

        // Métodos CRUD para Proveedor
        public Task<List<Proveedor>> GetAllProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();
        public Task<Proveedor> GetProveedorAsync(int id) => _database.Table<Proveedor>().FirstOrDefaultAsync(p => p.Id == id);
        public Task<int> SaveProveedorAsync(Proveedor proveedor) => proveedor.Id != 0 ? _database.UpdateAsync(proveedor) : _database.InsertAsync(proveedor);
        public Task<int> DeleteProveedorAsync(int id) => _database.DeleteAsync<Proveedor>(id);

        // Métodos CRUD para Orden
        public Task<List<Orden>> GetAllOrdenesAsync() => _database.Table<Orden>().ToListAsync();
        public Task<Orden> GetOrdenAsync(int id) => _database.Table<Orden>().FirstOrDefaultAsync(o => o.Id == id);
        public Task<int> SaveOrdenAsync(Orden orden) => orden.Id != 0 ? _database.UpdateAsync(orden) : _database.InsertAsync(orden);
        public Task<int> DeleteOrdenAsync(int id) => _database.DeleteAsync<Orden>(id);
    }
}
