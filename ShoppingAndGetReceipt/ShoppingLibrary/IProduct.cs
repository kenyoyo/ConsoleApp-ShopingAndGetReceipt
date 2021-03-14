using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public interface IProduct
    {
        ProductName Name { get; set; }
        double Price { get; set; }
    }
}
