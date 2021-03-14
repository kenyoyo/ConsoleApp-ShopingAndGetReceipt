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
    public class MedicineDiscountorTest
    {
        [Test]
        public void GetTotalDiscount_CustomerAgeGreaterThanOrEqualTo50_ShouldBe15PercentDiscountFromTotalMedicineCost()
        {
            IDiscountor medicineDiscountor;
            double expectedDiscount;
            double actualDiscount;

            medicineDiscountor = GetMedicineDiscountor(GetShoppingBagHave500TotalMedicineProductCost(), GetCustomer(50));
            expectedDiscount = 500 * 0.15;
            actualDiscount = medicineDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedDiscount, actualDiscount);

            medicineDiscountor = GetMedicineDiscountor(GetShoppingBagHave800TotalMedicineProductCost(), GetCustomer(68));
            expectedDiscount = 800 * 0.15;
            actualDiscount = medicineDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }

        [Test]
        public void GetTotalDiscount_CustomerAgeLesserThan50_TotalDiscountShouldBeZero()
        {
            IDiscountor medicineDiscountor;
            double expectedDiscount = 0;
            double actualDiscount;

            medicineDiscountor = GetMedicineDiscountor(GetShoppingBagHave500TotalMedicineProductCost(), GetCustomer(49));
            actualDiscount = medicineDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedDiscount, actualDiscount);

            medicineDiscountor = GetMedicineDiscountor(GetShoppingBagHave800TotalMedicineProductCost(), GetCustomer(32));
            actualDiscount = medicineDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }

        [TestCase(58)]
        [TestCase(83)]
        public void GetTotalDiscount_HaveNothingMedicineProductInBag_TotalDiscountShouldBeZero(int customerAge)
        {
            IDiscountor medicineDiscountor = GetMedicineDiscountor(GetShoppingBagHaveNothingMedicineProduct(), GetCustomer(customerAge));
            double expectedDiscount = 0;
            double actualDiscount = medicineDiscountor.GetTotalDiscount();
            Assert.AreEqual(expectedDiscount, actualDiscount);
        }

        public IShoppingBag GetShoppingBagHave500TotalMedicineProductCost()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 250));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 250));
            shoppingBag.AddProduct(new Product(ProductName.Snack, 100));
            return shoppingBag;
        }

        public IShoppingBag GetShoppingBagHave800TotalMedicineProductCost()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 400));
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Medicine, 400));
            shoppingBag.AddProduct(new Product(ProductName.Snack, 100));
            return shoppingBag;
        }

        public IShoppingBag GetShoppingBagHaveNothingMedicineProduct()
        {
            IShoppingBag shoppingBag = new ShoppingBag();
            shoppingBag.AddProduct(new Product(ProductName.Book, 159));
            shoppingBag.AddProduct(new Product(ProductName.Snack, 100));
            return shoppingBag;
        }

        public ICustomer GetCustomer(int age)
        {
            return new Customer("Test", age);
        }

        public IDiscountor GetMedicineDiscountor(IShoppingBag shoppingBag, ICustomer customer)
        {
            return new MedicineDiscounter(shoppingBag, customer);
        }
    }
}
