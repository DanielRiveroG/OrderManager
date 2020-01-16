using SQLite;
using System;

namespace OrderManager.Models
{
    public class Order
    {
        public Order()
        {

        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Customer { get; set; }

        public string OrderDetail { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DeliverDate { get; set; }
    }
}
