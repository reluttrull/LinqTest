using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinqTest
{
    public static class Math
    {
        public static double Average(this IEnumerable<Int32> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            long sum = collection.Sum();
            return (double)sum / (double)collection.Count();
        }
        public static double Average(this IEnumerable<Int64> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            long sum = collection.Sum();
            return (double)sum / (double)collection.Count();
        }
        public static float Average(this IEnumerable<Single> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            float sum = collection.Sum();
            return sum / collection.Count();
        }
        public static double Average(this IEnumerable<Double> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            double sum = 0;
            foreach (double num in collection)
            {
                sum += num;
            }
            if (Double.IsPositiveInfinity(sum)) return sum; // don't bother dividing if overflow
            return sum / collection.Count();
        }
        public static decimal Average(this IEnumerable<Decimal> collection)
        {
            if (collection is null || collection.Count() == 0) return 0;
            decimal sum = collection.Sum();
            return sum / collection.Count();
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

        public static Int32 Sum(this IEnumerable<Int32> collection)
        {
            Int32 sum = 0;
            foreach (Int32 num in collection)
            {
                try
                {
                    checked
                    {
                        sum += num;
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return sum;
        }
        public static Int64 Sum(this IEnumerable<Int64> collection)
        {
            Int64 sum = 0;
            foreach (Int64 num in collection)
            {
                try
                {
                    checked
                    {
                        sum += num;
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return sum;
        }
        public static Single Sum(this IEnumerable<Single> collection)
        {
            Single sum = 0;
            foreach (Single num in collection)
            {
                sum += num;
            }
            return Single.IsInfinity(sum) ? throw new OverflowException() : sum;
        }
        public static Double Sum(this IEnumerable<Double> collection)
        {
            Double sum = 0;
            foreach (Double num in collection)
            {
                sum += num;
            }
            return Double.IsInfinity(sum) ? throw new OverflowException() : sum;
        }
        public static Decimal Sum(this IEnumerable<Decimal> collection)
        {
            Decimal sum = 0;
            foreach (Decimal num in collection)
            {
                try
                {
                        sum += num;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
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

        public static Int32? Max(this IEnumerable<Int32> collection)
        {
            if (collection.Count() == 0) return null;
            Int32 max = Int32.MinValue;
            foreach (Int32 num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Int32? Max(this IEnumerable<Int32?> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            Int32? max = collection.FirstOrDefault();
            foreach (Int32? num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Int64? Max(this IEnumerable<Int64> collection)
        {
            if (collection.Count() == 0) return null;
            Int64 max = Int64.MinValue;
            foreach (Int64 num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Int64? Max(this IEnumerable<Int64?> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            Int64? max = collection.FirstOrDefault();
            foreach (Int64? num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Single? Max(this IEnumerable<Single> collection)
        {
            if (collection.Count() == 0) return null;
            Single max = Single.MinValue;
            foreach (Single num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Single? Max(this IEnumerable<Single?> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            Single? max = collection.FirstOrDefault();
            foreach (Single? num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Double? Max(this IEnumerable<Double> collection)
        {
            if (collection.Count() == 0) return null;
            Double max = Double.MinValue;
            foreach (Double num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Double? Max(this IEnumerable<Double?> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            Double? max = collection.FirstOrDefault();
            foreach (Double? num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Decimal? Max(this IEnumerable<Decimal> collection)
        {
            if (collection.Count() == 0) return null;
            Decimal max = Decimal.MinValue;
            foreach (Decimal num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static Decimal? Max(this IEnumerable<Decimal?> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);
            Decimal? max = collection.FirstOrDefault();
            foreach (Decimal? num in collection)
            {
                if (num > max) max = num;
            }
            return max;
        }
        public static T? Max<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            if (collection.Count() == 0) return default(T);
            T max = collection.ElementAt(0);
            foreach (T item in collection)
            {
                if (item.CompareTo(max) > 0) max = item;
            }
            return max;
        }
    }
}
