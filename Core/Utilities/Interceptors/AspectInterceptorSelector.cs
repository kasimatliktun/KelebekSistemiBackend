using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            try
            {
                var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
                //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));//otomatik olarak sistemdeki tüm metotları log a dahil et demektir.

            }
            catch (AmbiguousMatchException ex)
            {
                Console.WriteLine("\n{0}\n{1}", ex.GetType().FullName, ex.Message);
            }
            catch
            {
                Console.WriteLine("\nSome other exception.");
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
