using MiAppCrud.Models;
using MiAppCrud.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MiAppCrud.Controllers
{
    public class ProveedorController
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "proveedores.db3");
            _proveedorService = new ProveedorService(dbPath);
        }

        public Task<List<Proveedor>> GetAllProveedores() => _proveedorService.GetAll();
        public Task AddProveedor(Proveedor proveedor) => _proveedorService.Add(proveedor);
        public Task UpdateProveedor(Proveedor proveedor) => _proveedorService.Update(proveedor);
        public Task DeleteProveedor(int id) => _proveedorService.Delete(id);
    }
}
