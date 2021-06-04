using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule // Dependency Injection
    {
        public override void Load() // NinjectModule'den gelen load metodu.
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope(); // Ivalidator türünde (Product için) bir validation'a ihtiyaç duyarsa o zaman ona ProductValidator'u ver.
                                                                                    // Sıngleton olarak özellik ekleyerek performansımızı arttırıyoruz.
        }
    }
}
