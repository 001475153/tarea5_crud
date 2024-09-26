using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAppCrud.Views
{
    public partial class CategoriaListPage : ContentPage
    {
        private readonly CategoriaController _controller;

        public CategoriaListPage()
        {
            InitializeComponent();
            _controller = new CategoriaController();
            LoadCategorias();
        }

        private async void LoadCategorias()
        {
            CategoriaListView.ItemsSource = await _controller.GetAllCategorias();
        }

        private async void OnCategoriaTapped(object sender, ItemTappedEventArgs e)
        {
            var categoria = (Categoria)e.Item;
            await Navigation.PushAsync(new CategoriaEditPage(categoria));
        }

        private async void OnAddCategoriaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaEditPage());
        }
    }
}