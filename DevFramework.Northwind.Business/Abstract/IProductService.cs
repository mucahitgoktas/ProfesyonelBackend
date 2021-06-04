using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(Product product);
        void TransactionalOperation(Product product1, Product product2); // Transaction yönetimi: birkaç işlem üst-üste aynı anda yapılırken işlem zincirinde hata olursa, işlemleri geri alma.
                                                                         // Örneğin; hesaptan para yolladı hesaptan bakiye düştü ama karşıya bakiye eklenirken hata oluştu.
                                                                         // Bu durumda işlemler geri alınması gerekir.

    }
}
