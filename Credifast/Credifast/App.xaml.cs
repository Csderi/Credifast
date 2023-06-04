using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Credifast.Views.ViewsAcceso;
using Credifast.Data;
using SQLite;


namespace Credifast
{
    public partial class App : Application
    {
        public static DatabaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            InitalizeDatabase();

            MainPage = new NavigationPage(new StartPage());
        }

        private void InitalizeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "ToDo.db3");
            Context = new DatabaseContext(dbPath);
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