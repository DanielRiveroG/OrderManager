using OrderManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public NewOrderPage()
        {
            BindingContext = new NewOrderViewModel(Navigation);
            InitializeComponent();
        }
    }
}