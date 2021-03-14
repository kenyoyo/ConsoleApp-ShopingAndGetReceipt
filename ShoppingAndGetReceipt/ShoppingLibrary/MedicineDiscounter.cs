using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class MedicineDiscounter : IDiscountor
    {
        private IShoppingBag _shoppingBag;
        private ICustomer _customer;
        private int _discountPercentage = 15;

        public MedicineDiscounter(IShoppingBag shoppingBag, ICustomer customer)
        {
            _shoppingBag = shoppingBag;
            _customer = customer;
        }

        public double GetTotalDiscount()
        {
            if(_customer.Age < 50)
            {
                return 0;
            }

            var products = _shoppingBag.GetProductList();
            double totalMedicineCost = products.Where(x => x.Name == ProductName.Medicine).Sum(x => x.Price);
            return totalMedicineCost * _discountPercentage / 100;
        }
    }
}
