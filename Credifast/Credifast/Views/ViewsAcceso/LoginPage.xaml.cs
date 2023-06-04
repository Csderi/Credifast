using Credifast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Credifast.Views.ViewsAcceso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Btn_ClickedLogin(object sender, EventArgs e)
        {

            try
            {
                string email = gmail.Text;
                string password = Pass.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Por favor ingrese correo electrónico y contraseña", "Aceptar");
                    return;
                }

                // Buscar al usuario en la base de datos por su correo electrónico
                var user = await App.Context.GetItemByEmailAsync(email);

                if (user == null)
                {
                    await DisplayAlert("Error", "Usuario no encontrado", "Aceptar");
                    return;
                }

                // Verificar que la contraseña sea correcta
                if (user.Password != password)
                {
                    await DisplayAlert("Error", "Contraseña incorrecta", "Aceptar");
                    return;
                }

                // Autenticación exitosa, ir a la página principal
                await Navigation.PushAsync(new Principal_Page());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }

        public async void Olvido_Contrasena(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Changed_Password());
        }

    }
}