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

        // todo: this should really return int32 and throw an OverflowException if too big
        public static long Sum(this IEnumerable<int> collection)
        {
            long sum = 0;
            foreach (int num in collection)
            {
                sum += num;
            }
            return sum;
        }

        public static Int32? Min(this IEnumerable<Int32> collection)
        {
            if (collection.Count() == 0) return null;
            Int32 min = Int32.MaxValue;
            foreach (Int32 num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }
        public static Int64? Min(this IEnumerable<Int64> collection)
        {
            if (collection.Count() == 0) return null;
            Int64 min = Int64.MaxValue;
            foreach (Int64 num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }
        public static Single? Min(this IEnumerable<Single> collection)
        {
            if (collection.Count() == 0) return null;
            Single min = Single.MaxValue;
            foreach (Single num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }
        public static Double? Min(this IEnumerable<Double> collection)
        {
            if (collection.Count() == 0) return null;
            Double min = Double.MaxValue;
            foreach (Double num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }
        public static Decimal? Min(this IEnumerable<Decimal> collection)
        {
            if (collection.Count() == 0) return null;
            Decimal min = Decimal.MaxValue;
            foreach (Decimal num in collection)
            {
                if (num < min) min = num;
            }
            return min;
        }
        public static T? Min<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            if (collection.Count() == 0) return default(T);
            T min = collection.ElementAt(0);
            foreach (T item in collection)
            {
                if (item.CompareTo(min) < 0) min = item;
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
