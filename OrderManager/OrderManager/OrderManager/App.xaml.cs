using Xamarin.Forms;
using OrderManager.Services;
using OrderManager.Views;
using OrderManager.Models;
using System;
using System.IO;

namespace OrderManager
{
    public partial class App : Application
    {
        static OrderDatabase database;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        public static OrderDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new OrderDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OrdersSQLite.db3"));
                }
                return database;
            }
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
