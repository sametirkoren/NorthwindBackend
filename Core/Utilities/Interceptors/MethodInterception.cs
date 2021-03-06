﻿
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // method çalışmadan önce sen çalış
        protected virtual void OnBefore(IInvocation invocation) { } // invocation bizim methodumuz  

        // method çalıştıktan sonra sen çalış
        protected virtual void OnAfter(IInvocation invocation) { } // invocation bizim methodumuz

        // method hata verdiğinde sen çalış
        protected virtual void OnException(IInvocation invocation , System.Exception e ) { } // invocation bizim methodumuz

        // method başarılıysa sen çalış
        protected virtual void OnSuccess(IInvocation invocation) { } // invocation bizim methodumuz
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed(); // methodu çalıştır demek.
            }
            catch(Exception e)
            {
                isSuccess = false;
                OnException(invocation , e);
                throw;
            }

            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
