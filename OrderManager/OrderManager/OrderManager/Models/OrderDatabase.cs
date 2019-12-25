using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Models
{
    public class OrderDatabase
    {
        private SQLiteAsyncConnection _database;

        public OrderDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Order>().Wait();
        }

        public Task<List<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return _database.Table<Order>().Where(i => i.DeliverDate == date).ToListAsync();

        }

        public Task<int> SaveOrderAsync(Order item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteOrderAsync(Order item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<int> DeleteAllAsync()
        {
           return _database.DeleteAllAsync<Order>();
        }
    }
}
