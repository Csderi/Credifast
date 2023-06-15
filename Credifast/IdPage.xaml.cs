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
    public partial class IdPage : ContentPage
    {
        public IdPage()
        {
            InitializeComponent();
        }

        private async void Btn_Modificar(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(IdEntry.Text, out id))
            {
                var usuario = await App.Context.GetUsuarioAsync(id);
                if (usuario != null)
                {

                    await Navigation.PushAsync(new Detalle(usuario));

                }
                else
                {
                    await DisplayAlert("Error", "El ID especificado no existe en la base de datos.", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Error", "Por favor, ingresa un ID válido.", "Aceptar");
            }
        }


    }
}