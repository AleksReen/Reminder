using System;
using System.Web;
using System.Web.Caching;

namespace Reminder.Business.ReminderCache
{
    public class AppCache: IAppCache
    {

        public T GetValue<T>(string key, Func<T> method, int time) where T: class
        {
            if (HttpRuntime.Cache[key] != null)
            {
                return HttpRuntime.Cache.Get(key) as T;
            }

            var result = method();
            HttpRuntime.Cache.Insert(key, result, null, DateTime.Now.AddMinutes(time), Cache.NoSlidingExpiration);

            return result;
        }

        public void RemoveValue(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Remove(key);
            }  
        }

        public void SaveValue <T> (string key, T value, int time)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(time), Cache.NoSlidingExpiration);
        }
    }
}
