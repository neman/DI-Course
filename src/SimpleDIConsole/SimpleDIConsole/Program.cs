using Microsoft.Extensions.Configuration;
using SimpleDI.Interface;
using SimpleDIConsole.MessageWriter;
using System;
using System.IO;

namespace SimpleDIConsole
{
    class Program
    {

        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("DIConfig.json");

            Configuration = builder.Build();

            //TODO: Comment later for other examples
            //IMessageWriter writer = new ConsoleMessageWriter();
            //var salutation = new Salutation(writer);
            //salutation.Salute();

            //TODO: Remove to use late binding
            //var typeName = Configuration["MessageWriter"];
            //var type = Type.GetType(typeName, true);
            //IMessageWriter writer = (IMessageWriter)Activator.CreateInstance(type);
            //var salutation = new Salutation(writer);
            //salutation.Salute();

            //TODO: Remove to Use Decorator Pattern
            IMessageWriter writer = new SecureMessageWriter(new ConsoleMessageWriter());
            var salutation = new Salutation(writer);
            salutation.Salute();

        }
    }
}