using Microsoft.Maui.Controls;
using MiAppCrud.Models;
using MiAppCrud.Controllers;
using System;

namespace MiAppCrud.Views
{
    public partial class ProveedorListPage : ContentPage
    {
        private ProveedorController _controller;

        public ProveedorListPage()
        {
            InitializeComponent();
            _controller = new ProveedorController();
            LoadProveedores();
        }

        private async void LoadProveedores()
        {
            ProveedoresListView.ItemsSource = await _controller.GetAllProveedores();
        }

        private async void OnProveedorTapped(object sender, ItemTappedEventArgs e)
        {
            var proveedor = (Proveedor)e.Item;
            await Navigation.PushAsync(new ProveedorEditPage(proveedor));
        }

        private async void OnAddProveedorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProveedorEditPage());
        }

        private async void OnUpdateProveedorClicked(object sender, EventArgs e)
        {
            var proveedor = (Proveedor)ProveedoresListView.SelectedItem;
            if (proveedor != null)
            {
                await Navigation.PushAsync(new ProveedorEditPage(proveedor));
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un proveedor para actualizar.", "OK");
            }
        }

        private async void OnDeleteProveedorClicked(object sender, EventArgs e)
        {
            var proveedor = (Proveedor)ProveedoresListView.SelectedItem;
            if (proveedor != null)
            {
                bool confirm = await DisplayAlert("Confirmar", $"¿Estás seguro de que deseas borrar al proveedor '{proveedor.Nombre}'?", "Sí", "No");
                if (confirm)
                {
                    await _controller.DeleteProveedor(proveedor.Id);
                    LoadProveedores(); 
                }
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un proveedor para borrar.", "OK");
            }
        }
    }
}
