using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSystem;

namespace ShoppingSystem
{
    public class Receipt
    {
        private string CustomerName;
        List<string> products;

        public Receipt(string CustomerName)
        {
            this.CustomerName = CustomerName;
            products = new List<string>();
        }

        public void AddProduct(string product)
        {
            product.Add(product);
        }

        public override string ToString()
        {
            double sum = 0;
            Console.WriteLine("Receipt of " + CustomerName);
            foreach (var item in products)
            {
                sum += item.Price;
                item.ToString();
            }
            return ($"{sum}");
        }
    }
}
