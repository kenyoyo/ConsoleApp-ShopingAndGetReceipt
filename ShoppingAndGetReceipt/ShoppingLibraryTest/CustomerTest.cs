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
    public class CustomerTest
    {
        [Test]
        public void SetAge_AgeLessThanZero_AgeShouldBeOne()
        {
            ICustomer customer = new Customer("Test", -5);
            int expectedAge = 1;
            int actualAge = customer.Age;
            Assert.AreEqual(expectedAge, actualAge);
        }

        [Test]
        public void SetName_NameEmptyString_NameShouldBeCustomer()
        {
            ICustomer customer = new Customer("", 27);
            string expectedName = "Customer";
            string actualName = customer.Name;
            Assert.AreSame(expectedName, actualName);
        }
    }
}
