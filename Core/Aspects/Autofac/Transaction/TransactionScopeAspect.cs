using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                // başarılıysa
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                // başarılı değilse yapılan işlemleri geri al
                catch
                {
                    transactionScope.Dispose();
                    
                    throw;
                }
            }
        }
    }
}
