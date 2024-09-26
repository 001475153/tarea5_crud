using System;
using MiAppCrud.Models;  
using MiAppCrud.Controllers;  

namespace MiAppCrud.Views
{
    public partial class ProveedorEditPage : ContentPage
    {
        public ProveedorEditPage(Proveedor proveedor = null)
        {
            InitializeComponent();

            
            if (proveedor == null)
            {
                BindingContext = new Proveedor(); 
            }
            else
            {
                BindingContext = proveedor;  
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var proveedor = (Proveedor)BindingContext;  


            ProveedorController proveedorController = new ProveedorController();

            await DisplayAlert("Éxito", "Proveedor guardado exitosamente", "OK");

            await Navigation.PopAsync();
        }
    }
}
