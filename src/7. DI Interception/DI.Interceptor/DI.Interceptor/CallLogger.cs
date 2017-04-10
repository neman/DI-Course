using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DI.Interceptor
{
    public class CallLogger : IInterceptor
    {
        TextWriter _output;

        public CallLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            _output.WriteLine($"Target type method {invocation.TargetType} ");

           _output.WriteLine($"Calling method {invocation.Method.Name} " +
                                $"with parameters {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())}... ");

            
            invocation.Proceed();

            _output.WriteLine($"Done: result was {invocation.ReturnValue}.");
        }
    }    
}
