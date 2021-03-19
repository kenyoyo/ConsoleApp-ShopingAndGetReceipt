using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAndGetReceipt
{
    public static class MessageLogger
    {
        public static void ShowProgramName()
        {
            Console.WriteLine("***ShoppingAndReceipt Program***\n");
        }

        public static string AskName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static int AskAge()
        {
            Console.Write("Please enter your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return age;
        }

        public static void ShowThankYou()
        {
            Console.WriteLine("Thank you for buying our product.");
            AskForContinue();
        }

        public static void ShowReceipt(ICustomer customer, IShoppingBag shoppingBag)
        {
            ShowReceiptTitle(customer, shoppingBag);
            ShowAllAvailableProduct(shoppingBag.GetProductList());
            Console.WriteLine();
            ShowAllAvailableDiscount(customer, shoppingBag);
            Console.WriteLine();
            ShowPayCost(customer, shoppingBag);
            Console.WriteLine("--------------------\n");
        }

        private static void ShowReceiptTitle(ICustomer customer, IShoppingBag shoppingBag)
        {
            Console.WriteLine("-----Receipt-----");
            Console.WriteLine($"Customer: { customer.Name }  Age: { customer.Age }");
        }
        private static void ShowAllAvailableDiscount(ICustomer customer, IShoppingBag shoppingBag)
        {
            ShowSnackDiscount(shoppingBag);
            ShowFurnitureDiscount(shoppingBag);
            ShowMedicineDiscount(shoppingBag, customer);
        }

        private static void ShowSnackDiscount(IShoppingBag shoppingBag)
        {
            IDiscountor snackDiscountor = ShoppingFactory.GetBuyTwoGetOneFreeSnackDiscountor(shoppingBag);
            double snackTotalDiscount = snackDiscountor.GetTotalDiscount();

            if (snackTotalDiscount > 0)
            {
                Console.WriteLine($"Discount from snack promotion: ${ snackTotalDiscount }");
            }
        }

        private static void ShowFurnitureDiscount(IShoppingBag shoppingBag)
        {
            IDiscountor furnitureDiscountor = ShoppingFactory.GetFurnitureDiscountor(shoppingBag);
            double furnitureTotalDiscount = furnitureDiscountor.GetTotalDiscount();

            if (furnitureTotalDiscount > 0)
            {
                Console.WriteLine($"Discount from furniture promotion: ${ furnitureTotalDiscount }");
            }
        }

        private static void ShowMedicineDiscount(IShoppingBag shoppingBag, ICustomer customer)
        {
            IDiscountor medicineDiscountor = ShoppingFactory.GetMedicineDiscountor(shoppingBag, customer);
            double medicineTotalDiscount = medicineDiscountor.GetTotalDiscount();

            if (medicineTotalDiscount > 0)
            {
                Console.WriteLine($"Discount from medicine promotion: ${ medicineTotalDiscount }");
            }
        }

        private static void ShowPayCost(ICustomer customer, IShoppingBag shoppingBag)
        {
            var expensesCalculator = ShoppingFactory.GetExpensesCalculator(shoppingBag, customer);
            Console.WriteLine($"Product total cost: ${ expensesCalculator.GetTotalCost() }");
            Console.WriteLine($"Product total discount: ${ expensesCalculator.GetTotalDiscount() }");
            Console.WriteLine("Vat percentage is 7%.");
            Console.WriteLine($"Total pay: ${ expensesCalculator.GetTotalPay() }");
        }

        public static void ShowProductOnShoppingBag(IEnumerable<IProduct> products)
        {
            Console.WriteLine("This is product on your shopping bag.");
            ShowAllAvailableProduct(products);
            Console.WriteLine();
        }

        private static void ShowAllAvailableProduct(IEnumerable<IProduct> products)
        {
            for (int productNumber = 0; productNumber < 5; productNumber++)
            {
                ShowProduct(products, (ProductName)productNumber);
            }
        }

        private static void ShowProduct(IEnumerable<IProduct> products, ProductName productName)
        {
            int productCount = products.Where(x => x.Name == productName).Count();
            double totalCost = products.Where(x => x.Name == productName).Sum(x => x.Price);

            if (productCount > 0)
            {
                Console.WriteLine($" - {productCount} { productName } total cost: ${totalCost}.");
            }
        }
        
        public static int AskProductQuantity(string productName)
        {
            Console.WriteLine($"You have select {productName}, How many would you like?");
            Console.Write("Please enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return quantity;
        }

        public static void ShowPromotion()
        {
            Console.WriteLine("Promotion Discount\n"
                            + " - Buy 2 get 1 free for snack product.\n"
                            + " - For total furniture product with cost greater than or equal to 500 will get 10 % discount.\n"
                            + " - Customer Age greater than or equal to 50 years old will get 15 % discount\n"
                            + " from total medicine produst cost.\n");
        }

        public static void AskForContinue()
        {
            Console.Write("Please enter to continue...");
            Console.ReadLine();
            Console.WriteLine();
        }

        public static int AskSelectActivityNumber()
        {
            Console.WriteLine("What would you like to do next?\n"
                            + " 1. Continue buying another product.\n"
                            + " 2. Pay & Get Receipt.");
            Console.Write("Please select activity number: ");
            int selectNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return selectNumber;
        }

        public static void ShowSelectProductNumber()
        {
            Console.WriteLine("Select product number would you like to buy.\n"
                            + " 1. Snack $100\n 2. Book $239\n 3. Furniture $299\n"
                            + " 4. Kitchen Equipment $259\n 5. Medicine $200");
        }

        public static int AskSelectProductNumber()
        {
            Console.Write("Please enter product number: ");
            int selectProductNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return selectProductNumber;
        }
    }
}
