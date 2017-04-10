using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DataModel;
using System;

namespace DI.Interceptor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Product>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(CallLogger));
            builder.Register(c => new CallLogger(Console.Out));
            var container = builder.Build();
            
            var product = container.Resolve<Product>();

            product.DoStuff(5);
            
        }         
    }
}