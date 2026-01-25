using System;
using System.Collections.Generic;

namespace LinqTest
{
    public static class MyLinq
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> collection,
            Func<TSource, TResult> transformation)
        {
            List<TResult> result = [];
            foreach (TSource item in collection)
            {
                result.Add(transformation(item));
            }
            return result;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> result = [];
            foreach (T item in collection)
            {
                if (predicate(item)) result.Add(item);
            }
            return result;
        }

        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).Count() > 0;
        }

        public static IEnumerable<T1> OrderBy<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> prop) 
                where T2 : IComparable<T2>
        {
            Comparer<T1> comparer = Comparer<T1>.Create((x, y) => prop(x).CompareTo(prop(y)));
            var sorted = collection.ToList();
            sorted.Sort(comparer);
            return sorted;
        }

        public static IEnumerable<T1> OrderByDescending<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> prop) 
                where T2 : IComparable<T2>
        {
            Comparer<T1> comparer = Comparer<T1>.Create((x, y) => prop(y).CompareTo(prop(x)));
            var sorted = collection.ToList();
            sorted.Sort(comparer);
            return sorted;
        }

        public static T First<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0) throw new InvalidOperationException();
            return collection.ElementAt(0);
        }

        public static T First<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).First();
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0) return default(T);
            return collection.ElementAt(0);
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).FirstOrDefault(); 
        }
    }
}
