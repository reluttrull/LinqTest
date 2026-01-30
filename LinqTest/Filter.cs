using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            foreach (T item in collection)
            {
                if (predicate(item)) return true;
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T item in collection)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static bool Contains<T>(this IEnumerable<T> collection, T item)
        {
            if (collection.Count() == 0) return false;
            return collection.Any(i => i?.Equals(item) ?? (item is null));
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> collection)
        {
            Dictionary<int, T> dict = [];
            foreach (T item in collection)
            {
                int key = item?.GetHashCode() ?? 0;
                dict.TryAdd(key, item);
            }
            return dict.Values;
        }
    }
}
