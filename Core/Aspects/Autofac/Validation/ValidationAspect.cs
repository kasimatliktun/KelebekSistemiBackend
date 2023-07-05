using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding deniliyor bu yönteme - validationType, validasyon sınıfı mı diye bakıyoruz
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//atanan bir ıvalidation mu, kafasına göre yazılmasın için
            {
                throw new System.Exception("Bu bir doğrulama sınfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında new liyor yani örnek oluşturuyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Student validationun çalışma türünü bul yani student yani
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//parametrelerini bul (birden fazla olabilir) ve student olanları bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
