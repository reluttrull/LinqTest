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

        public static int Count<T>(this IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
            {
                count++; 
            }
            return count;
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

        public static int? Min(this IEnumerable<int> collection)
        {
            if (collection.Count() == 0) return null;
            int min = int.MaxValue;
            foreach (int num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }

        public static int? Max(this IEnumerable<int> collection)
        {
            if (collection.Count() == 0) return null;
            int min = int.MinValue;
            foreach (int num in collection)
            {
                if (num > min) min = num;
            }
            return min;
        }
    }
}
