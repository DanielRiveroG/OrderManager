using System;

namespace OrderManager.Models
{
    public class Order
    {
        public Order(string customer, string orderDetail, DateTime deliverDate)
        {
            Customer = customer;
            OrderDetail = orderDetail;
            DeliverDate = deliverDate;
        }

        public string Customer { get; set; }

        public string OrderDetail { get; set; }

        public DateTime DeliverDate { get; set; }
    }
}
