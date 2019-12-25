using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingOrdersPage : ContentPage
    {
        public PendingOrdersPage()
        {
            InitializeComponent();
        }

        async void AddOrder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}