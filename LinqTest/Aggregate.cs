using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Aggregators
    {
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> collection, 
            Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, TResult> finalTransform)
            where TAccumulate : struct
        {
            TAccumulate accumulation = default;
            foreach (TSource item in collection)
            {
                accumulation = accumulator(accumulation, item);
            }
            return finalTransform(accumulation);
        }
    }
}
