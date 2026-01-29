using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Sort
    {
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
    }
}
