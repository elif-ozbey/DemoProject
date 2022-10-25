using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validatortype in base taypini bul (abstract validatir),
            //onun generic argumanlarindan ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//ilgili merhodun parametrelerini bul (invocation method demek
              //Validaterin tipine esit olan parametreleri git bul                                                                       )
            foreach (var entity in entities)//her birini tek tek gez
            {
                ValidationTool.Validate(validator, entity);//validation toolu kullanarak validate et
            }
        }
    }
}
