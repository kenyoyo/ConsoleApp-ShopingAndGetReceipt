using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class BuyTwoGetOneFreeSnackDiscountor : IDiscountor
    {
        private IShoppingBag _shoppingBag;
        public BuyTwoGetOneFreeSnackDiscountor(IShoppingBag shoppingBag)
        {
            _shoppingBag = shoppingBag;
        }

        public double GetTotalDiscount()
        {
            var products = _shoppingBag.GetProductList();
            int totalSnackProduct = products.Where(x => x.Name == ProductName.Snack).Count();

            if(totalSnackProduct < 3)
            {
                return 0;
            }

            double productCost = products.Where(x => x.Name == ProductName.Snack).FirstOrDefault().Price;
            return totalSnackProduct / 3 * productCost;
        }
    }
}
