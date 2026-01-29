using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinqTest
{
    public static class Math
    {
        public static double Average(this IEnumerable<int> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            long sum = collection.Sum();
            return (double)sum / (double)collection.Count();
        }

        public static long Sum(this IEnumerable<int> collection)
        {
            long sum = 0;
            foreach (int num in collection)
            {
                sum += num;
            }
            return sum;
        }
    }
}
