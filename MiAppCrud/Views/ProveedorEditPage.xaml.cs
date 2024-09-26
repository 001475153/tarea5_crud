using MiAppCrud.Models;
using MiAppCrud.Controllers;
using System;

namespace MiAppCrud.Views
{
    public partial class ProveedorEditPage : ContentPage
    {
        private Proveedor _proveedor;
        private readonly ProveedorController _controller;

        public ProveedorEditPage(Proveedor proveedor = null)
        {
            InitializeComponent();
            _controller = new ProveedorController();
            _proveedor = proveedor ?? new Proveedor(); // Crea un nuevo proveedor si es null
            BindingContext = _proveedor; // Establece el contexto de enlace

            // Llenar los campos con la información del proveedor si existe
            if (_proveedor != null)
            {
                NombreProveedorEntry.Text = _proveedor.Nombre;
                TelefonoEntry.Text = _proveedor.Telefono;
            }
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Actualizar los campos del modelo
            _proveedor.Nombre = NombreProveedorEntry.Text;
            _proveedor.Telefono = TelefonoEntry.Text;

            // Guardar el objeto proveedor en la base de datos
            if (_proveedor.Id == 0)
                await _controller.AddProveedor(_proveedor);
            else
                await _controller.UpdateProveedor(_proveedor);

            await Navigation.PopAsync(); // Regresar a la página anterior
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (_proveedor.Id != 0)
            {
                await _controller.DeleteProveedor(_proveedor.Id); // Eliminar el proveedor si existe
            }

            await Navigation.PopAsync(); // Regresar a la página anterior
        }
    }
}
