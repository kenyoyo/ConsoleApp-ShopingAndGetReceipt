using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public interface IExpensesCalculator
    {
        double GetTotalCost();
        double GetTotalDiscount();
        double GetTotalPay();
    }
}
