using NUnit.Framework;
using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibraryTest
{
    [TestFixture]
    public class BuyTwoGetOneFreeSnackDiscountorTest
    {
        [TestCase(3, 35)]
        [TestCase(16, 10)]
        [TestCase(25, 30.25)]
        [TestCase(2, 0)]
        [TestCase(0, 0)]
        public void GetTotalDiscount_VariousTotalSnackProduct_ShouldDiscountByOneOnThreeSnackProduct(int totalSnackProduct, double productCost)
        {
            IShoppingBag shoppingBag = GetShoppingBag(totalSnackProduct, productCost);
            IDiscountor snackDiscountor = new BuyTwoGetOneFreeSnackDiscountor(shoppingBag);
            double expectedTotalDiscount = productCost * (totalSnackProduct / 3);
            double actualTotalDiscount = snackDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);
        }

        public IShoppingBag GetShoppingBag(int totalSnackProduct, double productCost)
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.KitchenEquipment, 195.50));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 150));
            
            for(int i=0; i<totalSnackProduct; i++)
            {
                shoppingBag.AddProduct(new Product(ProductName.Snack, productCost));
            }

            return shoppingBag;
        }
    }
}
