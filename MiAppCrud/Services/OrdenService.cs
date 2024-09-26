using MiAppCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAppCrud.Services
{
    public class OrdenService
    {
        private readonly Database _database;

        public OrdenService(string dbPath)
        {
            _database = new Database(dbPath);
        }

        public Task<List<Orden>> GetAll() => _database.GetAllOrdenesAsync();
        public Task Add(Orden orden) => _database.SaveOrdenAsync(orden);
        public Task Update(Orden orden) => _database.SaveOrdenAsync(orden);
        public Task Delete(int id) => _database.DeleteOrdenAsync(id);
    }
}
