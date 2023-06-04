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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void RegisterNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void LoginNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}