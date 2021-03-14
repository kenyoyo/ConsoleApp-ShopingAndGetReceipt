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
    public class ShoppingBagTest
    {
        [Test]
        public void AddProduct_AddingTwoProduct_TotalProductInBagShouldHaveTwo()
        {
            IShoppingBag shoppingBag = GetShoppingBag();
            shoppingBag.AddProduct(GetProduct());
            shoppingBag.AddProduct(GetProduct());
            var products = shoppingBag.GetProductList();
            int expectedTotalProducts = 2;
            int actualTotalProducts = products.Count();
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }
        
        [Test]
        public void RemoveProduct_RemoveTwoProductFromTotalFive_TotalProductInBagShouldHaveThree()
        {
            IShoppingBag shoppingBag = GetShoppingBag();
            IProduct testProduct = GetProduct();
            
            for (int i = 0; i < 5; i++)
            {
                shoppingBag.AddProduct(testProduct);
            }

            for (int i = 0; i < 2; i++)
            {
                shoppingBag.RemoveProduct(testProduct);
            }

            var products = shoppingBag.GetProductList();
            int expectedTotalProducts = 3;
            int actualTotalProducts = products.Count();
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }

        [Test]
        public void RemoveProduct_RemoveProductThatNotInBag_TotalProductShouldNotChange()
        {
            IShoppingBag shoppingBag = GetShoppingBag();
            IProduct productInBag = GetProduct();
            IProduct productNotInBag = GetProduct();
            shoppingBag.AddProduct(productInBag);
            shoppingBag.RemoveProduct(productNotInBag);
            var products = shoppingBag.GetProductList();
            int expectedTotalProducts = 1;
            int actualTotalProducts = products.Count();
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }

        public IShoppingBag GetShoppingBag()
        {
            return new ShoppingBag();
        }

        public IProduct GetProduct()
        {
            return new Product(ProductName.Medicine);
        }
    }
}
