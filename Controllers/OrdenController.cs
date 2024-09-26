using MiAppCrud.Services;
using MiAppCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAppCrud.Controllers
{
    public class OrdenController
    {
        private readonly OrdenService _ordenService;

        public OrdenController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _ordenService = new OrdenService(dbPath);
        }

        public async Task<List<Orden>> GetAllOrden()
        {
            return await _ordenService.GetAll();
        }

        public async Task AddOrden(Orden orden)
        {
            await _ordenService.Add(orden);
        }

        public async Task UpdateOrden(Orden orden)
        {
            await _ordenService.Update(orden);
        }

        public async Task DeleteOrden(int id)
        {
            await _ordenService.Delete(id);
        }
    }

}
