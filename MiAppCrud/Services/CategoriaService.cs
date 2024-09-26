using MiAppCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAppCrud.Services
{
    public class CategoriaService
    {
        private readonly Database _database;

        public CategoriaService(string dbPath)
        {
            _database = new Database(dbPath);
        }

        public Task<List<Categoria>> GetAll() => _database.GetAllCategoriasAsync();
        public Task Add(Categoria categoria) => _database.SaveCategoriaAsync(categoria);
        public Task Update(Categoria categoria) => _database.SaveCategoriaAsync(categoria);
        public Task Delete(int id) => _database.DeleteCategoriaAsync(id);
    }
}