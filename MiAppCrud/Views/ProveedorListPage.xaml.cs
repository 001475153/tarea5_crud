using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MiAppCrud.Views
{
    public partial class ProveedorListPage : ContentPage
    {
        private readonly ProveedorController _controller;

        public ProveedorListPage()
        {
            InitializeComponent();
            _controller = new ProveedorController();
            LoadProveedores();
        }

        private async void LoadProveedores()
        {
            ProveedorListView.ItemsSource = await _controller.GetAllProveedores();
        }

        private async void OnProveedorTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Proveedor proveedor)
            {
                await Navigation.PushAsync(new ProveedorEditPage(proveedor));
            }
        }

        private async void OnAddProveedorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProveedorEditPage());
        }
    }
}
