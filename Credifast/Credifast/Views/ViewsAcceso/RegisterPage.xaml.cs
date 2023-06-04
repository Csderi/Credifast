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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Btn_CrearUsuario(object sender, EventArgs e)
        {
            try
            {
                string email = email2.Text;
                string username = Username.Text;
                string password = Contra.Text;
                string firstName = Primero.Text;
                string lastName = Segundo.Text;
                string age = edad.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(firstName) ||
                    string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(age))
                {
                    await DisplayAlert("Error", "Por favor complete todos los campos", "OK");
                    return;
                }

                // Patrón de expresión regular para verificar si el correo electrónico es válido
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                if (!Regex.IsMatch(email, pattern))
                {
                    await DisplayAlert("Error", "Ingrese un correo electrónico válido", "OK");
                    return;
                }

                // Verificar si el correo electrónico ya está registrado en la base de datos
                var existingUser = await App.Context.GetItemByEmailAsync(email);
                if (existingUser != null)
                {
                    await DisplayAlert("Error", "El correo electrónico ya está registrado", "OK");
                    return;
                }

                // El correo electrónico es válido, no está registrado y todos los campos están completados, continuar con el registro
                var item = new ToDoItem
                {
                    User = username,
                    Email = email,
                    Password = password,
                    First_Name = firstName,
                    Last_Name = lastName,
                    Edad = age
                };

                var result = await App.Context.InsertItemAsyn(item);

                if (result == 1)
                {
                    await DisplayAlert("Proceso", "Su usuario se guardó correctamente", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la tarea", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}