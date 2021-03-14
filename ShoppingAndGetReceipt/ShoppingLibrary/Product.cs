using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class Product : IProduct
    {
        public ProductName Name { get; set; }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                _price = value < 0 ? 0 : value;
            }
        }

        public Product(ProductName productName, double price = 0)
        {
            Name = productName;
            Price = price;
        }
    }
}
