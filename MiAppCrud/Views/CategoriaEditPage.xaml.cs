using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MiAppCrud.Views
{
    public partial class CategoriaEditPage : ContentPage
    {
        private Categoria _categoria;
        private readonly CategoriaController _controller;

        public CategoriaEditPage(Categoria categoria = null)
        {
            InitializeComponent();
            _controller = new CategoriaController();
            _categoria = categoria ?? new Categoria();
            if (_categoria.Id != 0)
            {
                NombreEntry.Text = _categoria.Nombre;
                DescripcionEntry.Text = _categoria.Descripcion;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescripcionEntry.Text;

            if (_categoria.Id == 0)
                await _controller.AddCategoria(_categoria);
            else
                await _controller.UpdateCategoria(_categoria);

            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_categoria.Id != 0)
                await _controller.DeleteCategoria(_categoria.Id);

            await Navigation.PopAsync();
        }
    }
}