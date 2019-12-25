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
        private List<Order> mockOrders;


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
            OrderList = new ObservableCollection<Order>();
            mockOrders = new List<Order>();

            for(int i = 0; i < 20; i++)
            {
                if(i % 2 == 0)
                {
                    mockOrders.Add(new Order($"Cliente {i}", $"Detalle {i}", DateTime.Today));
                }
                else
                {
                    TimeSpan timeSpan = new TimeSpan(24, 0, 0);
                    mockOrders.Add(new Order($"Cliente {i}", $"Detalle {i}", DateTime.Today + timeSpan));
                }
            }
            
            SelectedDate = DateTime.Today;
        }

        private void UpdateOrderList()
        {
            OrderList.Clear();
            foreach (var order in mockOrders)
            {
                if(SelectedDate.Date == order.DeliverDate.Date)
                {
                    OrderList.Add(order);
                }
            }
        }
    }
}
