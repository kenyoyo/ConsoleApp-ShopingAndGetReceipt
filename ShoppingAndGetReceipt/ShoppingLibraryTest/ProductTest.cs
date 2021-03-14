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
    public class ProductTest
    {
        [Test]
        public void SetPrice_PriceLessThanZero_PriceShouldBeZero()
        {
            IProduct product = new Product(ProductName.Snack, -45.50);
            double expectedPrice = 0;
            double actualPrice = product.Price;
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}
