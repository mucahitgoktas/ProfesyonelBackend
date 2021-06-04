using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute; // cashte ne kadar duracak?
        private ICacheManager _cacheManager; // hangi cash interface'ında duracak


        public CacheAspect(Type cacheType, int cacheByMinute=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }

        public override void RuntimeInitialize(MethodBase method) // postsharp metodunu override ediyoruz
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false) // defansif coding
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager) Activator.CreateInstance(_cacheType); // gönderilen _chachetype için bir instance oluşturur.

            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args) // metot çalıştırıldığında.
                                                                   // onInvoke metodu override ediyoruz.
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,//0
                args.Method.ReflectedType.Name,//1
                args.Method.Name);//2
            var arguments = args.Arguments.ToList();

            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>"))); // yukarıdan alınan değerleri yazıyoruz.

            if (_cacheManager.IsAdd(key)) // yukarıdaki metot cashte var mı?
            {
                args.ReturnValue = _cacheManager.Get<object>(key); // eğer caste varsa cashmanagerdan get yaparak object türünde key i bana yolla
            }
            base.OnInvoke(args);
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute); // eğer senaryo geçerli değilse o zaman ekle.

        }
    }
}
