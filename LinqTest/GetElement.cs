using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class GetElement
    {
        public static T ElementAt<T>(this IEnumerable<T> collection, int index)
        {
            if (index < 0 || index >= collection.Count()) { throw new ArgumentOutOfRangeException(); }

            if (collection is IList<T> list)
            {
                return list[index];
            }
            using IEnumerator<T> enumerator = collection.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (i == index) return enumerator.Current;
                i++;
            }
            throw new ArgumentOutOfRangeException(); // we shouldn't get here, but need to satisfy the compiler
        }

        public static T? ElementAtOrDefault<T>(this IEnumerable<T> collection, int index)
        {
            if (index < 0 || index >= collection.Count()) return default(T);

            if (collection is IList<T> list)
            {
                return list[index];
            }
            using IEnumerator<T> enumerator = collection.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (i == index) return enumerator.Current;
                i++;
            }
            return default(T); // we shouldn't get here, but need to satisfy the compiler
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

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection, T defaultValue)
        {
            if (collection.Count() == 0) return defaultValue;
            return collection.ElementAt(0);
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0) return default(T);
            return collection.ElementAt(0);
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate, T defaultValue)
        {
            return collection.Where(predicate).FirstOrDefault(defaultValue);
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).FirstOrDefault();
        }

        public static T Single<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var matches = collection.Where(predicate);
            if (matches.Count() > 1) throw new InvalidOperationException();
            return matches.First();
        }

        public static T? SingleOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var matches = collection.Where(predicate);
            if (matches.Count() > 1) throw new InvalidOperationException();
            return matches.FirstOrDefault();
        }
    }
}
