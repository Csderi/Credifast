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
    public partial class Ganancias : ContentPage
    {
        private List<Usuario> usuarios;

        public Ganancias()
        {
            InitializeComponent();

            usuarios = new List<Usuario>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            usuarios = await App.Context.GetItemsAsync();

            // Calcular las ganancias generales sumando el pago al mes de cada usuario
            float gananciasGenerales = usuarios.Sum(u => u.PagoAlMes);

            // Mostrar las ganancias generales en el título de la página
            Title = $"Ganancias Generales: {gananciasGenerales}";

            // Actualizar la lista de ganancias en el ListView
            gananciasListView.ItemsSource = usuarios.Select(u => new GananciaItem { Nombre = u.Nombre, Ganancia = u.PagoAlMes }).ToList();
        }

        private void GananciasListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Aquí puedes agregar la lógica para manejar la selección de un elemento del ListView, si lo deseas
        }
    }

    public class GananciaItem
    {
        public string Nombre { get; set; }
        public float Ganancia { get; set; }
    }
}