using Reminder.Common.Entity;
using System;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Reminder.Business.ReminderCache
{
    public class AppCache: IAppCache
    {

        public T GetValue<T>(string key, Func<T> method) where T: class
        {
            if (HttpRuntime.Cache[key] != null)
            {
                return HttpRuntime.Cache.Get(key) as T;
            }

            var result = method();
            HttpRuntime.Cache.Insert(key, result, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);

            return result;
        }

        public void RemoveValue(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public void SaveValue <T> (string key, T value)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
        }
    }
}
