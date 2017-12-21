using System;

namespace Reminder.Business.ReminderCache
{
    public interface IAppCache
    {
        T GetValue<T> (string key, Func<T> method, int time = 5) where T: class;
        void SaveValue<T> (string key, T value, int time = 5);
        void RemoveValue(string key); 
    }
}
