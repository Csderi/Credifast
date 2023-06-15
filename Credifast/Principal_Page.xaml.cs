using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Credifast.Views.ViewsAcceso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal_Page : ContentPage
    {
        public Principal_Page()
        {
            InitializeComponent();
        }

        public async void Clientes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro_Cliente());
        }

        public async void Modificaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IdPage());
        }

        public async void Perfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Perfiles());
        }

        public async void Ganancias_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ganancias());
        }



    }
}