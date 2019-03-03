using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectivityMonitorSample.Models;

namespace ConnectivityMonitorSample.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Online and offline functionality", Description="This functionality support both online and offline modes." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Online functionality", Description="This functionality only support online mode." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}