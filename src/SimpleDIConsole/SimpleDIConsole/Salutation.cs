using SimpleDI.Interface;
using System;

namespace SimpleDIConsole
{
    public class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            if (_writer == null)
            {
                this._writer = writer;
            }
        }

        public void Salute()
        {
            this._writer.Write("Hello DI!");            
        }
    }
}