using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderManager.ViewModels
{
    public class PendingOrdersViewModel : BaseViewModel
    {
        private DateTime _selectedDate;
        private string _someText;
        private DelegateCommand<Order> _deleteCommand;

        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                UpdateOrderList();
            }
        }

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                OnPropertyChanged(nameof(SomeText));
            }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new DelegateCommand<Order>(DeleteOrderFromList);}
        }

        public ObservableCollection<Order> OrderList { get; set; }


        public PendingOrdersViewModel()
        {
            //App.Database.DeleteAllAsync();
            OrderList = new ObservableCollection<Order>();
            SelectedDate = DateTime.Today;
            MessagingCenter.Subscribe<NewOrderViewModel>(this, "NewOrderAdded", (obj) =>
            {
                UpdateOrderList();
            });
        }

        private async void UpdateOrderList()
        {
            OrderList.Clear();
            List<Order> orders = await App.Database.GetOrdersByDateAsync(SelectedDate);
            foreach(Order order in orders)
            {
                OrderList.Add(order);
            }
        }

        private async void DeleteOrderFromList(Order parameter)
        {
            await App.Database.DeleteOrderAsync((Order)parameter);
            UpdateOrderList();
        }
    }
}
