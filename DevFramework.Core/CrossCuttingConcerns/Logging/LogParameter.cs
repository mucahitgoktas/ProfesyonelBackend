using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging // kim hangi metotu hangi parametrelerne ne zaman çalıştırdı gibi sebeplerle tutulan logları yöneten class.
{
    public class LogParameter
    {


        /* <örnek>
        public Product Add(Product product) // metot parametresinin; ismi : product, tipi: Product, Değeri : product'ın değeri neyse o.
        {
            return _productDal.Add(product);
        }
        </örnek> */
        public string Name { get; set; } // metot parametresinin ismi
        public string Type { get; set; } // metot parametresinin tipi
        public object Value { get; set; } // türün ne olacağını bilmediğimiz için "object"





        
    }
}
