using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class Customer : ICustomer
    {
        private string _name;
        public string Name 
        { 
            get => _name;
            set 
            {
                _name = string.IsNullOrEmpty(value) ? "Customer" : value;                
            } 
        }
        
        private int _age;
        public int Age
        {
            get => _age;
            set 
            {
                _age = value <= 0 ? 1 : value;
            }
        }

        public Customer(string name="Customer", int age=1)
        {
            Name = name;
            Age = age;
        }
    }
}
