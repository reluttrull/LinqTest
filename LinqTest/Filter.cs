using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Filter
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item)) yield return item;
            }
        }

        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).Count() > 0;
        }
    }
}
