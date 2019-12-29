using OrderManager.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderManager.ViewModels
{
    public class NewOrderViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private DelegateCommand _saveCommand;
        private DelegateCommand _cancelCommand;
        private string _customerName;
        private string _phoneNumber;
        private string _orderDetail;
        private DateTime _deliverDate;

        public NewOrderViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _deliverDate = DateTime.Today;
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveOrder); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand = _cancelCommand ?? new DelegateCommand(CancelNewOrder); }
        }

        public string CustomerName { 
            get 
            {
                return _customerName;
            } 
            set
            {
                _customerName = value;
            } 
        }   
        
        public string PhoneNumber { 
            get 
            {
                return _phoneNumber;
            } 
            set
            {
                _phoneNumber = value;
            } 
        }

        public string OrderDetail { 
            get 
            {
                return _orderDetail;
            } 
            set
            {
                _orderDetail = value;
            } 
        }
        
        public DateTime DeliverDate { 
            get 
            {
                return _deliverDate;
            } 
            set
            {
                _deliverDate = value;
            } 
        }

        private async void SaveOrder()
        {
            Order newOrder = new Order { Customer = _customerName, DeliverDate = _deliverDate, PhoneNumber = PhoneNumber, OrderDetail = _orderDetail };
            await App.Database.SaveOrderAsync(newOrder);
            await _navigation.PopModalAsync();
            MessagingCenter.Send(this, "NewOrderAdded");
        }

        private async void CancelNewOrder()
        {
            await _navigation.PopModalAsync();
        }
    }
}
