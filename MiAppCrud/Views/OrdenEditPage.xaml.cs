using MiAppCrud.Controllers;
using MiAppCrud.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class OrdenEditPage : ContentPage
    {
        private Orden _orden;
        private ProductoController _productoController;

        public OrdenEditPage(Orden orden = null)
        {
            InitializeComponent();
            _orden = orden ?? new Orden();
            _productoController = new ProductoController();

            LoadProductos();
        }

        

        private async void LoadProductos()
        {
            var productos = await _productoController.GetAllProductos();
            ProductoPicker.ItemsSource = productos;
            ProductoPicker.ItemDisplayBinding = new Binding("Nombre"); // Suponiendo que Producto tiene una propiedad "Nombre"
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _orden.Fecha = DateTime.Parse(FechaEntry.Text);
            // Corregido el nombre del Picker a ProductoPicker
            _orden.ProductoId = (ProductoPicker.SelectedItem as Producto)?.Id ?? 0;

            var controller = new OrdenController();
            if (_orden.Id == 0)
                await controller.AddOrden(_orden);
            else
                await controller.UpdateOrden(_orden);

            await Navigation.PopAsync();
        }
    }
}
