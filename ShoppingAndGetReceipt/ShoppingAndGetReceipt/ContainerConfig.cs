using Autofac;
using ShoppingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAndGetReceipt
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Customer>().As<ICustomer>();
            builder.RegisterType<ShoppingBag>().As<IShoppingBag>();
            builder.RegisterType<Application>().As<IApplication>();
            return builder.Build();
        }
    }
}
