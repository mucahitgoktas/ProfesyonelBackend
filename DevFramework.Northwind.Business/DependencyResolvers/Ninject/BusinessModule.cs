using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()// Ninject modülden gelen load operasyonu var.
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //eğer biri senden IprodctService isterse ProductManager'ı ver.
            Bind<IProductDal>().To<EfProductDal>(); //eğer biri IproductDal isterse EfProductDal ver.



            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>)); // DevFramework.Core.DataAccess içerisindeki IQueryableRepository'ye Bind koyduk.
            Bind<DbContext>().To<NorthwindContext>(); // eğer biri senden DbContext türünde birşey isterse onu NorthWindContext'e bağla.
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
