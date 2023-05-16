using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Credifast.Views.ViewsAcceso;


namespace Credifast
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
