using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MiAppCrud.Services;
using MiAppCrud.Models;

namespace MiAppCrud.Controllers
{
    public class ProveedorController
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _proveedorService = new ProveedorService(dbPath);
        }

        public async Task<List<Proveedor>> GetAllProveedores()
        {
            return await _proveedorService.GetAll();
        }

        public async Task AddProveedor(Proveedor proveedor)
        {
            await _proveedorService.Add(proveedor);
        }

        public async Task UpdateProveedor(Proveedor proveedor)
        {
            await _proveedorService.Update(proveedor);
        }

        public async Task DeleteProveedor(int id)
        {
            await _proveedorService.Delete(id);
        }
    }
}
