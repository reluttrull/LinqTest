namespace LinqTest
{
    public static class MyLinq
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> input,
            Func<TSource, TResult> transformation)
        {
            List<TResult> result = [];
            foreach (TSource item in input)
            {
                result.Add(transformation(item));
            }
            return result;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> input, Func<T, bool> predicate)
        {
            List<T> result = [];
            foreach (T item in input)
            {
                if (predicate(item)) result.Add(item);
            }
            return result;
        }

        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).Count() > 0;
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
