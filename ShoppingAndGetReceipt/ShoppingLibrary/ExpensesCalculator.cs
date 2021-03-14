using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class ExpensesCalculator : IExpensesCalculator
    {
        private IShoppingBag _shoppingBag;
        private IEnumerable<IDiscountor> _discountors;
        private const double TAX_RATE = 0.07;

        public ExpensesCalculator(IShoppingBag shoppingBag, 
            IEnumerable<IDiscountor> discountors)
        {
            _shoppingBag = shoppingBag;
            _discountors = discountors;
        }

        public double GetTotalCost()
        {
            return _shoppingBag.GetProductList().Sum(x => x.Price);
        }

        public double GetTotalDiscount()
        {
            return _discountors.Sum(x => x.GetTotalDiscount());
        }

        public double GetTotalPay()
        {
            double totalCost = _shoppingBag.GetProductList().Sum(x => x.Price);
            double totalDiscount = _discountors.Sum(x => x.GetTotalDiscount());
            return (totalCost - totalDiscount) * TAX_RATE; 
        }
    }
}
