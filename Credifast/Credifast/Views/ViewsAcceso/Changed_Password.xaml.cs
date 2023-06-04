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
    public partial class Changed_Password : ContentPage
    {
        public Changed_Password()
        {
            InitializeComponent();
        }

        private async void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {
            // Validar que se haya ingresado un correo electrónico
            if (string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                await DisplayAlert("Error", "Ingresa un correo electrónico válido.", "OK");
                return;
            }

            // Validar que se haya ingresado una nueva contraseña
            if (string.IsNullOrWhiteSpace(NewPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Ingresa una nueva contraseña.", "OK");
                return;
            }

            try
            {
                // Obtener el objeto del usuario desde la base de datos utilizando el correo electrónico
                var user = await App.Context.GetItemByEmailAsync(EmailEntry.Text);

                if (user != null)
                {
                    // Actualizar la contraseña del usuario con la nueva contraseña ingresada
                    user.Password = NewPasswordEntry.Text;

                    // Actualizar el objeto del usuario en la base de datos
                    await App.Context.UpdateItemAsync(user);

                    // Mostrar un mensaje de éxito y navegar hacia atrás
                    await DisplayAlert("Éxito", "¡Contraseña cambiada exitosamente!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "El correo electrónico no está registrado.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


    }
}