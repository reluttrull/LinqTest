using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Range
    {
        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            int index = 0;
            while (index < count && index < collection.Count())
            {
                yield return collection.ElementAt(index);
                index++;
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item)) yield return item;
                else break;
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> collection, int count)
        {
            int skipCount = int.Clamp(count, 0, collection.Count());
            for (int i = skipCount; i < collection.Count(); i++)
            {
                yield return collection.ElementAt(i);
            }
        }
    }
}