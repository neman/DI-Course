using SimpleDI.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security;
using System.Security.Principal;
using System.Security.Claims;

namespace SimpleDIConsole.MessageWriter
{
    public class SecureMessageWriter : IMessageWriter
    {

        private readonly IMessageWriter _writer;

        public SecureMessageWriter(IMessageWriter writer)
        {
            if(writer == null)
            {
                throw new ArgumentNullException();
            }
            this._writer = writer;
        }

        public void Write(string message)
        {
            if (IsUserAuthenticated())
            {
                _writer.Write(message);
            }
        }

        private bool IsUserAuthenticated()
        {
            //e.g. call to some Auth service
            return true;
        }
    }
}
