using Microsoft.Maui.Controls;

namespace MiAppCrud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            // Crea y devuelve una nueva ventana con tu contenido inicial
            return new Window(new AppShell());
        }
    }
}
