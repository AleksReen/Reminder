using System;

namespace Reminder.Common.HelperMethods
{
    public static class Extensions
    {
        public static bool Contains(this string source, string value, StringComparison compare)
        {
            return source.IndexOf(value, compare) >= 0;
        }
    }
}
