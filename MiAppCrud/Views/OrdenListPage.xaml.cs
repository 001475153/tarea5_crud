using MiAppCrud.Controllers;
using MiAppCrud.Models;
using System;
using System.Collections.Generic;

namespace MiAppCrud.Views
{
    public partial class OrdenListPage : ContentPage
    {
        private readonly OrdenController _controller;

        public OrdenListPage()
        {
            InitializeComponent();
            _controller = new OrdenController();
            LoadOrdenes();
        }

        private async void LoadOrdenes()
        {
            OrdenesListView.ItemsSource = await _controller.GetAllOrdenes();
        }

        private async void OnOrdenTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Orden orden)
            {
                await Navigation.PushAsync(new OrdenEditPage(orden));
            }
        }

        private async void OnAddOrdenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdenEditPage());
        }
    }
}
