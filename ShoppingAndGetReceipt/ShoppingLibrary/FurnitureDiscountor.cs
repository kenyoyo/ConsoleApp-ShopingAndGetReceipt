using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class FurnitureDiscountor : IDiscountor
    {
        private IShoppingBag _shoppingBag;
        private int _discountPercentage = 10;
        
        public FurnitureDiscountor(IShoppingBag shoppingBag)
        {
            _shoppingBag = shoppingBag;
        }

        public double GetTotalDiscount()
        {
            var products = _shoppingBag.GetProductList();
            var totalFurnitureCost = products.Where(x => x.Name == ProductName.Furniture).Sum(x => x.Price);

            if (totalFurnitureCost < 500)
            {
                return 0;
            }

            return totalFurnitureCost * _discountPercentage / 100;
        }
    }
}
