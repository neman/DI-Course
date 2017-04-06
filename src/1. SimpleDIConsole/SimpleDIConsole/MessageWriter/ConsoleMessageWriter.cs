using SimpleDI.Interface;
using System;

namespace SimpleDIConsole.MessageWriter
{
    internal class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}