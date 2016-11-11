namespace ConsoleApplication.Interceptors
{
    using Ninject.Extensions.Interception;
    using System.Collections.Concurrent;
    using System.Linq;

    public class TrimmedStringCachingInterceptor : IInterceptor
    {
        private readonly static ConcurrentDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        public void Intercept(IInvocation invocation)
        {
            var param = invocation.Request.Arguments.FirstOrDefault().ToString();

            if (cache.ContainsKey(param))
            {
                string value;
                cache.TryGetValue(param, out value);
                invocation.ReturnValue = value + " From cache.";
            }
            else
            {
                invocation.Proceed();
                cache.TryAdd(param, invocation.ReturnValue.ToString());
            }
        }
    }
}
