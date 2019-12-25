using OrderManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrderManager.ViewModels
{
    public class PendingOrdersViewModel : BaseViewModel
    {
        private DateTime _selectedDate;
        private string _someText;

        public DateTime SelectedDate {
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

        public string SomeText { 
            get { return _someText; } 
            set 
            { 
                _someText = value;
                OnPropertyChanged(nameof(SomeText));
            } 
        }

        public ObservableCollection<Order> OrderList { get; set; }


        public PendingOrdersViewModel()
        {
            App.Database.DeleteAllAsync();
            OrderList = new ObservableCollection<Order>();

            for(int i = 0; i < 20; i++)
            {
                if(i % 2 == 0)
                {
                    App.Database.SaveItemAsync(new Order($"Cliente {i}", $"Detalle {i}", DateTime.Today));
                }
                else
                {
                    TimeSpan timeSpan = new TimeSpan(24, 0, 0);
                    App.Database.SaveItemAsync(new Order($"Cliente {i}", $"Detalle {i}", DateTime.Today + timeSpan));
                }
            }
            
            SelectedDate = DateTime.Today;
        }

        private async void UpdateOrderList()
        {
            OrderList.Clear();
            List<Order> orders = await App.Database.GetOrdersByDateAsync(SelectedDate);
            foreach (var order in orders)
            {
                if (SelectedDate.Date == order.DeliverDate.Date)
                {
                    OrderList.Add(order);
                }
            }
        }
    }
}
