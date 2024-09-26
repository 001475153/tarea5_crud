using MiAppCrud.Controllers;
using MiAppCrud.Models;
using System;
using System.Linq;

namespace MiAppCrud.Views
{
    public partial class ProductoEditPage : ContentPage
    {
        private Producto _producto;
        private CategoriaController _categoriaController;

        public ProductoEditPage(Producto producto = null)
        {
            InitializeComponent();
            _producto = producto ?? new Producto();
            _categoriaController = new CategoriaController();

            LoadCategorias();

            if (_producto.Id != 0)
            {
                NombreEntry.Text = _producto.Nombre;
                PrecioEntry.Text = _producto.Precio.ToString();
                CategoriaPicker.SelectedItem = _producto.CategoriaId;
            }
        }

        private async void LoadCategorias()
        {
            var categorias = await _categoriaController.GetAllCategorias();
            CategoriaPicker.ItemsSource = categorias;
            CategoriaPicker.ItemDisplayBinding = new Binding("Nombre");
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _producto.Nombre = NombreEntry.Text;
            _producto.Precio = decimal.Parse(PrecioEntry.Text);
            _producto.CategoriaId = (CategoriaPicker.SelectedItem as Categoria)?.Id ?? 0;

            var controller = new ProductoController();
            if (_producto.Id == 0)
                controller.AddProducto(_producto);
            else
                controller.UpdateProducto(_producto);

            await Navigation.PopAsync();
        }
    }
}
