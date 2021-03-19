using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAndGetReceipt
{
    public static class ShoppingFactory 
    {
        public static IExpensesCalculator GetExpensesCalculator(IShoppingBag shoppingBag, ICustomer customer)
        {
            var discountors = new List<IDiscountor>();
            discountors.Add(GetBuyTwoGetOneFreeSnackDiscountor(shoppingBag));
            discountors.Add(GetFurnitureDiscountor(shoppingBag));
            discountors.Add(GetMedicineDiscountor(shoppingBag, customer));
            return new ExpensesCalculator(shoppingBag, discountors);
        }
        public static IDiscountor GetBuyTwoGetOneFreeSnackDiscountor(IShoppingBag shoppingBag)
        {
            return new BuyTwoGetOneFreeSnackDiscountor(shoppingBag);
        }

        public static IDiscountor GetFurnitureDiscountor(IShoppingBag shoppingBag)
        {
            return new FurnitureDiscountor(shoppingBag);
        }

        public static IDiscountor GetMedicineDiscountor(IShoppingBag shoppingBag, ICustomer customer)
        {
            return new MedicineDiscounter(shoppingBag, customer);
        }

        public static IProduct GetProduct(ProductName productName, double productCost)
        {
            return new Product(productName, productCost);
        }
    }
}
