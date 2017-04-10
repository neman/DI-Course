using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;

namespace DI.Interceptor
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<Product>().AsSelf()
            //.EnableClassInterceptors()
            //.InterceptedBy(typeof(CallLogger));

            ////builder.Register(c => new CallLogger(Console.Out));
            //builder.Register(c => new CallLogger(Console.Out)).Named<IInterceptor>("log-calls");
            //var container = builder.Build();

            //var product = container.Resolve<Product>();

            //product.Add();

            //Console.WriteLine("Hello World!");
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