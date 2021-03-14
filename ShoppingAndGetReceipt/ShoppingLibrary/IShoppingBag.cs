using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public interface IShoppingBag
    {
        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
        IEnumerable<IProduct> GetProductList();
    }
}
