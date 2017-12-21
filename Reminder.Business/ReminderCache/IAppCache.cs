using System;

namespace Reminder.Business.ReminderCache
{
    public interface IAppCache
    {
        T GetValue<T> (string key, Func<T> method) where T: class;
        void SaveValue<T> (string key, T value);
        void RemoveValue(string key); 
    }
}
