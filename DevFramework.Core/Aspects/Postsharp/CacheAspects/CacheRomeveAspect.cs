using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    class CacheRemoveAspect:OnMethodBoundaryAdvice
    {
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cache)
        {
            _cacheType = _cacheType;
        }

        public CacheRemoveAspect(string pattern, Type cacheType)
        {
            _pattern = pattern;
            _cacheType = cacheType;
        }
        public override void RuntimeInitialize(MethodBase method) // postsharp metodunu override ediyoruz
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false) // defansif coding
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType); // gönderilen _chachetype için bir instance oluşturur.

            base.RuntimeInitialize(method);
        }

        override override void Onsuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
            ?string.Format("{0},{1}.*",args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name):_pattern);
        }
    }
}
