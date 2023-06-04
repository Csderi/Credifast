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
    public partial class Perfiles : ContentPage
    {
        public Perfiles()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Obtener la lista de usuarios desde la base de datos
            var usuarios = await App.Context.Connection.Table<Usuario>().ToListAsync();

            // Asignar la lista de usuarios como origen de datos para el ListView
            usuariosListView.ItemsSource = usuarios;

            LoadItems();
        }

        private async void LoadItems()
        {
            var usuario = await App.Context.GetItemsAsync();
            usuariosListView.ItemsSource = usuario;
        }


        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {

            if (await DisplayAlert("Confirmacion", "Estas seguro de eliminar el elemento", "Si", "No"))
            {
                var usuario = (Usuario)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(usuario);
                if (result == 1)
                {
                    LoadItems();
                }
            }


        }

    }
}