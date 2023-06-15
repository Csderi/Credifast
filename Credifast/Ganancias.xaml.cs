using Credifast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // Calcular el número de meses y la ganancia total por usuario
            var gananciaItems = usuarios.Select(u => new GananciaItem
            {
                Nombre = u.Nombre,
                Ganancia = u.PagoAlMes 
            }).ToList();

            // Actualizar la lista de ganancias en el ListView
            gananciasListView.ItemsSource = gananciaItems;
        }

        private int GetMeses(DateTime inicio, DateTime final)
        {
            int meses = 0;

            // Ajustar la fecha inicial al primer día del mes
            DateTime inicioMes = new DateTime(inicio.Year, inicio.Month, 1);

            // Calcular el número de meses completos
            meses = (final.Year - inicio.Year) * 12 + final.Month - inicio.Month;

            // Considerar los días restantes del mes inicial y el mes final
            double diasInicio = (inicio - inicioMes).TotalDays;
            double diasFinal = (final - new DateTime(final.Year, final.Month, 1)).TotalDays;
            double totalDias = DateTime.DaysInMonth(inicio.Year, inicio.Month);

            if (diasInicio > 0)
                meses += Convert.ToInt32((totalDias - diasInicio) / totalDias);
            if (diasFinal > 0)
                meses += Convert.ToInt32(diasFinal / totalDias);

            return meses;
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
