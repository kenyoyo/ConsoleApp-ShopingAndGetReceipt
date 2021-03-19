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
    public class ExpensesCalculatorTest
    {
        private const double TAX_RATE = 0.07;
        private double _furnitureCostForDiscountPromotionTest = 600;
        private double _medicineCostForDiscountPromotionTest = 100;
        private double _snackCostForDiscountPromotionTest = 100;

        [Test]
        public void AllGetTotalMethod_HaveNoDiscountCase_ShouldCalculateCorrectly()
        {
            IExpensesCalculator expensesCalculator = GetExpensesCalculatorThatHaveNothingDiscount();
            double expectedTotalCost = 900;
            double expectedtotalDiscount = 0;
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) + ((expectedTotalCost - expectedtotalDiscount) * TAX_RATE);
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        [Test]
        public void AllGetTotalMethod_HaveSnackDiscountCase_ShouldCalculateCorrectly()
        {
            IExpensesCalculator expensesCalculator = GetExpensesCalculatorThatHaveDiscountFromSnack();
            double expectedTotalCost = 1300;
            double expectedtotalDiscount = _snackCostForDiscountPromotionTest;
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) + ((expectedTotalCost - expectedtotalDiscount) * TAX_RATE);
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        [Test]
        public void AllGetTotalMethod_HaveFurnitureDiscountCase_ShouldCalculateCorrectly()
        {
            IExpensesCalculator expensesCalculator = GetExpensesCalculatorThatHaveDiscountFromFurniture();
            double expectedTotalCost = 1050;
            double expectedtotalDiscount = _furnitureCostForDiscountPromotionTest * 0.10;
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) + ((expectedTotalCost - expectedtotalDiscount) * TAX_RATE);
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        [Test]
        public void AllGetTotalMethod_HaveMedicineDiscountCase_ShouldCalculateCorrectly()
        {
            IExpensesCalculator expensesCalculator = GetExpensesCalculatorThatHaveDiscountFromMedicine();
            double expectedTotalCost = 900;
            double expectedtotalDiscount = _medicineCostForDiscountPromotionTest * 0.15;
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) + ((expectedTotalCost - expectedtotalDiscount) * TAX_RATE);
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        [Test]
        public void AllGetTotalMethod_HaveAllPromotionDiscountCase_ShouldCalculateCorrectly()
        {
            IExpensesCalculator expensesCalculator = GetExpensesCalculatorThatHaveAllDiscountPromotion();
            double expectedTotalCost = 1450;
            double expectedtotalDiscount = _snackCostForDiscountPromotionTest + (_furnitureCostForDiscountPromotionTest * 0.10) + (_medicineCostForDiscountPromotionTest * 0.15);
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) + ((expectedTotalCost - expectedtotalDiscount) * TAX_RATE);
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        [Test]
        public void AllGetTotalMethod_BagHaveNothingProduct_ShouldCalculateCorrectly()
        {
            IShoppingBag shoppingBag = GetShoppingBagHaveNothingProduct();
            IEnumerable<IDiscountor> discountors = GetDiscountors(20, shoppingBag);
            IExpensesCalculator expensesCalculator = GetExpensesCalculator(shoppingBag, discountors);
            double expectedTotalCost = 0;
            double expectedtotalDiscount = 0;
            double expectedtotalPay = (expectedTotalCost - expectedtotalDiscount) * TAX_RATE;
            double actualTotalCost = expensesCalculator.GetTotalCost();
            double actualTotalDiscount = expensesCalculator.GetTotalDiscount();
            double actualTotalPay = expensesCalculator.GetTotalPay();
            Assert.AreEqual(expectedTotalCost, actualTotalCost);
            Assert.AreEqual(expectedtotalDiscount, actualTotalDiscount);
            Assert.AreEqual(expectedtotalPay, actualTotalPay);
        }

        public IExpensesCalculator GetExpensesCalculatorThatHaveDiscountFromSnack()
        {
            IShoppingBag shoppingBag = GetShoppingBag(5, 450);
            IEnumerable<IDiscountor> discountors = GetDiscountors(24, shoppingBag);
            return GetExpensesCalculator(shoppingBag, discountors);
        }

        public IExpensesCalculator GetExpensesCalculatorThatHaveDiscountFromFurniture()
        {
            IShoppingBag shoppingBag = GetShoppingBag(1, _furnitureCostForDiscountPromotionTest);
            IEnumerable<IDiscountor> discountors = GetDiscountors(24, shoppingBag);
            return GetExpensesCalculator(shoppingBag, discountors);
        }

        public IExpensesCalculator GetExpensesCalculatorThatHaveDiscountFromMedicine()
        {
            IShoppingBag shoppingBag = GetShoppingBag(1, 450);
            IEnumerable<IDiscountor> discountors = GetDiscountors(60, shoppingBag);
            return GetExpensesCalculator(shoppingBag, discountors);
        }

        public IExpensesCalculator GetExpensesCalculatorThatHaveAllDiscountPromotion()
        {
            IShoppingBag shoppingBag = GetShoppingBag(5, _furnitureCostForDiscountPromotionTest);
            IEnumerable<IDiscountor> discountors = GetDiscountors(60, shoppingBag);
            return GetExpensesCalculator(shoppingBag, discountors);
        }

        public IExpensesCalculator GetExpensesCalculatorThatHaveNothingDiscount()
        {
            IShoppingBag shoppingBag = GetShoppingBag(1, 450);
            IEnumerable<IDiscountor> discountors = GetDiscountors(24, shoppingBag);
            return GetExpensesCalculator(shoppingBag, discountors);
        }

        public IEnumerable<IDiscountor> GetDiscountors(int customerAge, IShoppingBag shoppingBag)
        {
            var discountors = new List<IDiscountor>();
            discountors.Add(new BuyTwoGetOneFreeSnackDiscountor(shoppingBag));
            discountors.Add(new FurnitureDiscountor(shoppingBag));
            discountors.Add(new MedicineDiscounter(shoppingBag, new Customer("Test", customerAge)));
            return discountors;
        }

        public IShoppingBag GetShoppingBagHaveNothingProduct()
        {
            return new ShoppingBag();
        }
        
        public IShoppingBag GetShoppingBag(int totalSnackProduct, double totalFurnitureCost)
        {
            var shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Book, 150));
            shoppingBag.AddProduct(new Product(ProductName.Furniture, totalFurnitureCost));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, _medicineCostForDiscountPromotionTest));
            shoppingBag.AddProduct(new Product(ProductName.KitchenEquipment, 100));

            for(int i=0; i<totalSnackProduct; i++)
            {
                shoppingBag.AddProduct(new Product(ProductName.Snack, _snackCostForDiscountPromotionTest));
            }

            return shoppingBag;
        }

        public IExpensesCalculator GetExpensesCalculator(IShoppingBag shoppingBag, IEnumerable<IDiscountor> discountors)
        {
            return new ExpensesCalculator(shoppingBag, discountors);
        }
    }
}
