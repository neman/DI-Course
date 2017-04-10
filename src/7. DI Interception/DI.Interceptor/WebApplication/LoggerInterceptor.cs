using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class LoggerInterceptor : IInterceptor
    {
        ILoggerFactory _loggerFactory;

        public LoggerInterceptor(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            var logger = _loggerFactory.CreateLogger(invocation.TargetType);
            logger.LogInformation($"Target type method {invocation.Method.Name} ");
           

            invocation.Proceed();

            logger.LogInformation($"Done {invocation.Method.Name} ");
        }
    }
}
