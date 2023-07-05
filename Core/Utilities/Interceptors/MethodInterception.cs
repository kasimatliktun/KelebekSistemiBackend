using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        //invocaion, business katmanındaki metodlar
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);//methodun başında çalışır En çok 1. bu çalışır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);//hata aldığında çalışır. En çok 2. bu çalışır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//method başarılı olursa burası çalışıyor
                }
            }
            OnAfter(invocation);//metotdan sonra çalışsın istersen bu çalışsın.
        }
    }
}
