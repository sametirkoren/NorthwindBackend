using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true); // Add gibi getlist gibi hangi method çalıştırılıyorsa onun custom attributelarını al

            classAttributes.AddRange(methodAttributes);

            // Bütün methodlara exception attributeları ekle
            classAttributes.Add(new ExceptionLogAspcet(typeof(FileLogger))); 
            classAttributes.Add(new ExceptionLogAspcet(typeof(DatabaseLogger)));
           


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
