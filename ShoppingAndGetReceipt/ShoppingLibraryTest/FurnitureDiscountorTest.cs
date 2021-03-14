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
    public class FurnitureDiscountorTest
    {
        [Test]
        public void GetTotalDiscount_TotalFurnitureCostGreaterThanOrEqualsTo500_ShouldBe10PercentDiscountFromTotalFurnitureCost()
        {
            IDiscountor furnitureDiscountor;
            double expectedTotalDiscount;
            double actualTotalDiscount;

            furnitureDiscountor = GetFurnitureDiscountor(GetShoppingBagThatHaveFurnitureProductTotalCostIs500());
            expectedTotalDiscount = 500 * 0.10;
            actualTotalDiscount = furnitureDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);

            furnitureDiscountor = GetFurnitureDiscountor(GetShoppingBagThatHaveFurnitureProductTotalCostIs600());
            expectedTotalDiscount = 600 * 0.10;
            actualTotalDiscount = furnitureDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);

            furnitureDiscountor = GetFurnitureDiscountor(GetShoppingBagThatHaveFurnitureProductTotalCostIs1000());
            expectedTotalDiscount = 1000 * 0.10;
            actualTotalDiscount = furnitureDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);
        }

        [Test]
        public void GetTotalDiscount_TotalFurnitureCostLesserThan500_TotalDiscountShouldBeZero()
        {
            IDiscountor furnitureDiscountor = GetFurnitureDiscountor(GetShoppingBagThatHaveFurnitureProductTotalCostIs300());
            double expectedTotalDiscount = 0;
            double actualTotalDiscount = furnitureDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);
        }

        public void GetTotalDiscount_HaveNothingFurnitureProductInBag_TotalDiscountShouldBeZero()
        {
            IDiscountor furnitureDiscountor = GetFurnitureDiscountor(GetShoppingBagThatHaveNothingFurnitureProduct());
            double expectedTotalDiscount = 0;
            double actualTotalDiscount = furnitureDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedTotalDiscount, actualTotalDiscount);
        }

        public IShoppingBag GetShoppingBagThatHaveFurnitureProductTotalCostIs500()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 500));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 180));
            return shoppingBag;
        }

        public IShoppingBag GetShoppingBagThatHaveFurnitureProductTotalCostIs600()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 300));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 300));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 180));
            return shoppingBag;
        }

        public static IShoppingBag GetShoppingBagThatHaveFurnitureProductTotalCostIs1000()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 300));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 300));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 200));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 180));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 200));
            return shoppingBag;
        }        

        public IShoppingBag GetShoppingBagThatHaveFurnitureProductTotalCostIs300()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Furniture, 300));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 180));
            return shoppingBag;
        }

        public IShoppingBag GetShoppingBagThatHaveNothingFurnitureProduct()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 180));
            return shoppingBag;
        }

        public IDiscountor GetFurnitureDiscountor(IShoppingBag shoppingBag)
        {
            return new FurnitureDiscountor(shoppingBag);
        }
    }
}
