using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VendingMachine
    {
        public int Capacity { get; private set; }
        public List<Product> Items { get; private set; }

        public VendingMachine(int capacity)
        {
            Capacity = capacity;
            Items = new List<Product>();
        }

        public void AddItem(Product item)
        {
            if (Items.Count >= Capacity)
                throw new Exception("No more room in Vending Machine");
            
            Items.Add(item);
        }

        public decimal BuyItem(string productName, decimal money)
        {
            var product = Items.Find((product) => product.Name == productName);

            if (product == null || product.Price > money)
                throw new Exception("Not enough Money");
            
            Items.Remove(product);

            return Math.Round(money - product.Price, 2);
        }

        public void ShowCatalog()
        {
            foreach (var product in Items)
            {
                Console.WriteLine($"{product.Name}: ${product.Price}");
            }
        }
    }
}