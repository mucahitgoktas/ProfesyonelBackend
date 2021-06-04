using System;
using System.Linq;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // validatorType'ın baseType'ının yani Üst tipinin generic argumanını al.
            var entities = args.Arguments.Where(t=>t.GetType()==entityType); // args çalıştırılan metotla ilgili bilgi almamızı sağlar.

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
