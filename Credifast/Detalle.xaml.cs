using Credifast.Models;
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
    public partial class Detalle : ContentPage
    {
        private Usuario usuario;

        public Detalle(Usuario selectedUsuario)
        {
            InitializeComponent();
            usuario = selectedUsuario;
            LoadUsuarioDetails();
        }

        private void LoadUsuarioDetails()
        {
            NombreEntry.Text = usuario.Nombre;
            GmailEntry.Text = usuario.Gmail;
            TelefonoEntry.Text = usuario.NumeroTelefono;
            DomicilioEntry.Text = usuario.Domicilio;
        }

        private async void GuardarButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                usuario.Nombre = NombreEntry.Text;
                usuario.Gmail = GmailEntry.Text;
                usuario.NumeroTelefono = TelefonoEntry.Text;
                usuario.Domicilio = DomicilioEntry.Text;

                // Realizar la actualización en la base de datos
                int result = await App.Context.UpdateUsuarioAsync(usuario);

                if (result > 0)
                {
                    await DisplayAlert("Éxito", "Los datos se actualizaron correctamente", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo actualizar los datos", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}