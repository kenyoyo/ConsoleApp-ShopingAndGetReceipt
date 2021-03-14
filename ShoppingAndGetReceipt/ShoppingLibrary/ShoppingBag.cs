using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class ShoppingBag : IShoppingBag
    {
        private List<IProduct> _products = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public IEnumerable<IProduct> GetProductList()
        {
            return _products;
        }

        public void RemoveProduct(IProduct product)
        {
            _products.Remove(product);
        }
    }
}
