using Credifast.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Credifast.Views.ViewsAcceso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro_Cliente : ContentPage
    {
        public Registro_Cliente()
        {
            InitializeComponent();
        }

        private async void GuardarButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string nombre = nombreEntry.Text;
                string gmail = gmailEntry.Text;
                string telefono = telefonoEntry.Text;
                string domicilio = domicilioEntry.Text;
                float cantidadPrestada = float.Parse(cantidadEntry.Text);
                float interes = float.Parse(interesEntry.Text);
                DateTime inicio = inicioDatePicker.Date;
                DateTime final = finalDatePicker.Date;

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(gmail) ||
                    string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(domicilio))
                {
                    await DisplayAlert("Error", "Por favor complete todos los campos obligatorios", "OK");
                    return;
                }

                // Validación de la fecha final
                DateTime fechaFinalMinima = inicio.AddMonths(1); // Fecha de inicio más un mes
                if (final < fechaFinalMinima)
                {
                    await DisplayAlert("Error", "La fecha final debe ser al menos un mes después de la fecha de inicio", "OK");
                    return;
                }

                // Cálculo del PagoAlMes
                TimeSpan duracionPrestamo = final - inicio;
                int totalMeses = (int)(duracionPrestamo.TotalDays / 30);
                float totalInteres = cantidadPrestada * interes;
                float pagoAlMes = (cantidadPrestada + totalInteres) / totalMeses;

                Usuario usuario = new Usuario
                {
                    Nombre = nombre,
                    Gmail = gmail,
                    NumeroTelefono = telefono,
                    Domicilio = domicilio,
                    Cantidad_prestada = cantidadPrestada,
                    Interes = interes,
                    Inicio = inicio,
                    Final = final,
                    PagoAlMes = pagoAlMes
                };

                int result = await App.Context.InsertUsuarioAsync(usuario);

                if (result > 0)
                {

                    
                    await DisplayAlert("Éxito", "Los datos se guardaron correctamente", "Aceptar");
                    LimpiarCampos();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar los datos", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private void LimpiarCampos()
        {
            nombreEntry.Text = "";
            gmailEntry.Text = "";
            telefonoEntry.Text = "";
            domicilioEntry.Text = "";
            cantidadEntry.Text = "";
            interesEntry.Text = "";

            inicioDatePicker.Date = DateTime.Now;
            finalDatePicker.Date = DateTime.Now;
        }
    }
}
