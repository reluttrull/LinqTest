using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Map
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> collection,
            Func<TSource, TResult> transformation)
        {
            foreach (TSource item in collection)
            {
                yield return transformation(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> collection,
            Func<TSource, IEnumerable<TResult>> transformation)
        {
            foreach (TSource item in collection)
            {
                foreach (TResult resultItem in transformation(item))
                {
                    yield return resultItem;
                }
            }
        }
    }
}
