using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft // datayı uygulama sunucusunun belleğinde tutan microsft .net altyapısı.
                                                                   // dış kaynaklarda; memcach reditcach gibi daha gelişmiş cach altyapıları mevcut
{
    public class MemoryCacheManager:ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default; // dışardan erişimsiz "protected"

        public T Get<T>(string key)
        {
            return (T)Cache[key]; // mevcut cash datalarından verdiğim key isimli cash'i T'ye döndür ve bana ver.
        }

        public void Add(string key, object data, int cacheTime=60)
        {                                       // eğer bana gönderdiğin data null ise o zaman return.
            if (data==null)
            {
                return;
            }

            var policy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)}; // eğer data null değilse, datetime.now'dan itibaren bana gönderdiğin cashtime kadar tut.
            Cache.Add(new CacheItem(key, data), policy); 
        }

        public bool IsAdd(string key) 
        {
            return Cache.Contains(key); // benim key ile gönderdiğim data cash'te var mı?
        }

        public void Remove(string key)
        {
            Cache.Remove(key); // cashten sil
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,RegexOptions.Singleline|RegexOptions.Compiled|RegexOptions.IgnoreCase); // kuralları veriyoruz.
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList(); // cash datası ile regexten match olanları listele ve bana ver.

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear() // cashteki bütün itemları sil.
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
