using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // Aspect : metodun başında sonunda hata verdiğinde çalışacak yapı. doğrulama metodun başında yapılır. o yüzden sadece on before u ezdik.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
           

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            
        }
    }
}
