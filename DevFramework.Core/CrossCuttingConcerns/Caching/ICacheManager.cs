using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager // hangi data hangi parametrelerle çağırılmışsa ona göre işlem yapmamız gerek.
    {
        T Get<T>(string key);
        void Add(string key,object data,int cacheTime); // key, data, cash ne kadar süreyle bellekte kalacak?
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}
