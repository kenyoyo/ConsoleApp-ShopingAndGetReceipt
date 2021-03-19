using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAndGetReceipt
{
    public class Application : IApplication
    {
        private ICustomer _customer;
        private IProduct _product;
        private IShoppingBag _shoppingBag;

        public Application(ICustomer customer, IShoppingBag shoppingBag)
        {
            _customer = customer;
            _shoppingBag = shoppingBag;
        }

        public void Run()
        {
            Begin();
            During();
            End();
        }        

        private void Begin()
        {
            MessageLogger.ShowProgramName();
            AskCustomerInformation();
            MessageLogger.ShowPromotion();
            MessageLogger.AskForContinue();
        }
        private void AskCustomerInformation()
        {
            _customer.Name = MessageLogger.AskName();
            _customer.Age = MessageLogger.AskAge();
        }

        private void During()
        {
            do
            {
                SelectProduct();
                MessageLogger.ShowProductOnShoppingBag(_shoppingBag.GetProductList());
                MessageLogger.AskForContinue();

                if (MessageLogger.AskSelectActivityNumber() == 2)
                {
                    break;
                }
            } while (true);
        }

        private void SelectProduct()
        {
            MessageLogger.ShowSelectProductNumber();
            int selectProductNumber = MessageLogger.AskSelectProductNumber();
            switch (selectProductNumber)
            {
                case 1:
                    _product = ShoppingFactory.GetProduct(ProductName.Snack, 100);
                    break;
                case 2:
                    _product = ShoppingFactory.GetProduct(ProductName.Book, 239);
                    break;
                case 3:
                    _product = ShoppingFactory.GetProduct(ProductName.Furniture, 299);
                    break;
                case 4:
                    _product = ShoppingFactory.GetProduct(ProductName.KitchenEquipment, 259);
                    break;
                case 5:
                    _product = ShoppingFactory.GetProduct(ProductName.Medicine, 200);
                    break;
                default:
                    break;
            }

            int quantity = MessageLogger.AskProductQuantity(_product.Name.ToString());

            for (int i = 0; i < quantity; i++)
            {
                _shoppingBag.AddProduct(_product);
            }
        }

        private void End()
        {
            MessageLogger.ShowReceipt(_customer, _shoppingBag);
            MessageLogger.ShowThankYou();
        }
    }
}
