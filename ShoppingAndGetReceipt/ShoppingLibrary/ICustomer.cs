using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public interface ICustomer
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
