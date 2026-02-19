using LinqTest;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class MathTests
    {
        [Fact]
        public void SumInt32_WhenMultiple_ReturnsCorrectSum()
        {
            List<Int32> nums = [.. Range.Repeat(500, 10)];
            var sum = nums.Sum();
            Assert.Equal(5000, sum);
        }

        [Fact]
        public void SumInt32_WhenEmpty_ReturnsZero()
        {
            List<Int32> nums = [];
            var sum = nums.Sum();
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumInt32_WhenTooBig_ThrowsOverflow()
        {
            List<Int32> nums = [.. Range.Repeat(Int32.MaxValue, 3)];
            var caughtException = Assert.Throws<OverflowException>(() => nums.Sum());
        }

        [Fact]
        public void SumInt64_WhenMultiple_ReturnsCorrectSum()
        {
            List<Int64> nums = [.. Range.Repeat(500, 10)];
            var sum = nums.Sum();
            Assert.Equal(5000, sum);
        }

        [Fact]
        public void SumInt64_WhenEmpty_ReturnsZero()
        {
            List<Int64> nums = [];
            var sum = nums.Sum();
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumInt64_WhenTooBig_ThrowsOverflow()
        {
            List<Int64> nums = [.. Range.Repeat(Int64.MaxValue, 3)];
            var caughtException = Assert.Throws<OverflowException>(() => nums.Sum());
        }

        [Fact]
        public void SumSingle_WhenMultiple_ReturnsCorrectSum()
        {
            List<Single> nums = [.. Range.Repeat(500, 10)];
            var sum = nums.Sum();
            Assert.Equal(5000, sum);
        }

        [Fact]
        public void SumSingle_WhenEmpty_ReturnsZero()
        {
            List<Single> nums = [];
            var sum = nums.Sum();
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumSingle_WhenTooBig_ThrowsOverflow()
        {
            List<Single> nums = [.. Range.Repeat(Single.MaxValue, 3)];
            var caughtException = Assert.Throws<OverflowException>(() => nums.Sum());
        }

        [Fact]
        public void SumDouble_WhenMultiple_ReturnsCorrectSum()
        {
            List<Double> nums = [.. Range.Repeat(500, 10)];
            var sum = nums.Sum();
            Assert.Equal(5000, sum);
        }

        [Fact]
        public void SumDouble_WhenEmpty_ReturnsZero()
        {
            List<Double> nums = [];
            var sum = nums.Sum();
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumDouble_WhenTooBig_ThrowsOverflow()
        {
            List<Double> nums = [.. Range.Repeat(Double.MaxValue, 3)];
            var caughtException = Assert.Throws<OverflowException>(() => nums.Sum());
        }

        [Fact]
        public void SumDecimal_WhenMultiple_ReturnsCorrectSum()
        {
            List<Decimal> nums = [.. Range.Repeat(500, 10)];
            var sum = nums.Sum();
            Assert.Equal(5000, sum);
        }

        [Fact]
        public void SumDecimal_WhenEmpty_ReturnsZero()
        {
            List<Decimal> nums = [];
            var sum = nums.Sum();
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumDecimal_WhenTooBig_ThrowsOverflow()
        {
            List<Decimal> nums = [.. Range.Repeat(Decimal.MaxValue, 3)];
            var caughtException = Assert.Throws<OverflowException>(() => nums.Sum());
        }

        [Fact]
        public void AverageInt32_WhenMultipleAndNonIntegerResult_ReturnsCorrectAverage()
        {
            List<Int32> nums = [1, 2];
            var avg = nums.Average();
            Assert.Equal(1.5, avg);
        }
        [Fact]
        public void AverageInt32_WhenEmpty_ReturnsZero()
        {
            List<Int32> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }
        [Fact]
        public void AverageInt64_WhenMultipleAndNonIntegerResult_ReturnsCorrectAverage()
        {
            List<Int64> nums = [1, 2];
            var avg = nums.Average();
            Assert.Equal(1.5, avg);
        }
        [Fact]
        public void AverageInt64_WhenEmpty_ReturnsZero()
        {
            List<Int64> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }
        [Fact]
        public void AverageSingle_WhenMultiple_ReturnsCorrectAverage()
        {
            List<Single> nums = [1, 2];
            var avg = nums.Average();
            Assert.Equal(1.5, avg);
        }
        [Fact]
        public void AverageSingle_WhenEmpty_ReturnsZero()
        {
            List<Single> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }
        [Fact]
        public void AverageDouble_WhenMultiple_ReturnsCorrectAverage()
        {
            List<Double> nums = [1, 2.5];
            var avg = nums.Average();
            Assert.Equal(1.75, avg);
        }
        [Fact]
        public void AverageDouble_WhenOverflow_ReturnsInfinity()
        {
            List<Double> nums = [Double.MaxValue, Double.MaxValue];
            var avg = nums.Average();
            Assert.Equal(Double.PositiveInfinity, avg);
        }
        [Fact]
        public void AverageDouble_WhenEmpty_ReturnsZero()
        {
            List<Double> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }
        [Fact]
        public void AverageDecimal_WhenMultiple_ReturnsCorrectAverage()
        {
            List<Decimal> nums = [1, 2.5m];
            var avg = nums.Average();
            Assert.Equal(1.75m, avg);
        }
        [Fact]
        public void AverageDecimal_WhenEmpty_ReturnsZero()
        {
            List<Decimal> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }

        [Fact]
        public void Average_WhenEmpty_ReturnsZero()
        {
            List<int> nums = [];
            var avg = nums.Average();
            Assert.Equal(0, avg);
        }

        [Fact]
        public void Count_WhenEmpty_ReturnsZero()
        {
            List<Person> ls = [];
            var count = ls.Count();
            Assert.Equal(0, count);
        }

        [Fact]
        public void Count_WhenLargeNumberOfItems_ReturnsCorrectNumber()
        {
            List<Person> ls = [..Range.Repeat(new Person("name"), 54321)];
            var count = ls.Count();
            Assert.Equal(54321, count);
        }

        [Fact]
        public void MinInt32_WhenEmpty_ReturnsNull()
        {
            List<Int32> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinInt32_WhenNotEmpty_ReturnsSmallestInt32()
        {
            List<Int32> ls = [1, 2, -3, 4];
            var min = ls.Min();
            Assert.Equal(-3, min);
        }

        [Fact]
        public void MinInt64_WhenEmpty_ReturnsNull()
        {
            List<Int64> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinInt64_WhenNotEmpty_ReturnsSmallestInt64()
        {
            List<Int64> ls = [1, 2, -3, 4];
            var min = ls.Min();
            Assert.Equal(-3, min);
        }

        [Fact]
        public void MinSingle_WhenEmpty_ReturnsNull()
        {
            List<Single> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinSingle_WhenNotEmpty_ReturnsSmallestSingle()
        {
            List<Single> ls = [1, 2, -3, 4];
            var min = ls.Min();
            Assert.Equal(-3, min);
        }

        [Fact]
        public void MinDouble_WhenEmpty_ReturnsNull()
        {
            List<Double> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinDouble_WhenNotEmpty_ReturnsSmallestDouble()
        {
            List<Double> ls = [1, 2.5, -3, 4];
            var min = ls.Min();
            Assert.Equal(-3, min);
        }

        [Fact]
        public void MinDecimal_WhenEmpty_ReturnsNull()
        {
            List<Decimal> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinDecimal_WhenNotEmpty_ReturnsSmallestDecimal()
        {
            List<Decimal> ls = [1, 2.5m, -3, 4];
            var min = ls.Min();
            Assert.Equal(-3, min);
        }

        [Fact]
        public void MinString_WhenEmpty_ReturnsNull()
        {
            List<string> ls = [];
            var min = ls.Min();
            Assert.Null(min);
        }

        [Fact]
        public void MinString_WhenNotEmpty_ReturnsSmallestString()
        {
            List<string> ls = ["asdf", "0123", "jkl;"];
            var min = ls.Min();
            Assert.Equal("0123", min);
        }

        [Fact]
        public void MaxInt32_WhenEmpty_ReturnsNull()
        {
            List<Int32> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt32_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Int32> ls = [1, 2, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxInt32N_WhenNullCollection_ThrowsArgumentNullException()
        {
            List<Int32?> ls = null;
            var caughtException = Assert.Throws<ArgumentNullException>(() => ls!.Max());
        }

        [Fact]
        public void MaxInt32N_WhenEmpty_ReturnsNull()
        {
            List<Int32?> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt32N_WhenAllNull_ReturnsNull()
        {
            List<Int32?> ls = [null, null];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt32N_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Int32?> ls = [1, null, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxInt64_WhenEmpty_ReturnsNull()
        {
            List<Int64> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt64_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Int64> ls = [1, 2, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxInt64N_WhenNullCollection_ThrowsArgumentNullException()
        {
            List<Int64?> ls = null;
            var caughtException = Assert.Throws<ArgumentNullException>(() => ls!.Max());
        }

        [Fact]
        public void MaxInt64N_WhenEmpty_ReturnsNull()
        {
            List<Int64?> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt64N_WhenAllNull_ReturnsNull()
        {
            List<Int64?> ls = [null, null];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxInt64N_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Int64?> ls = [1, null, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxSingle_WhenEmpty_ReturnsNull()
        {
            List<Single> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxSingle_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Single> ls = [1, 2, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxSingleN_WhenNullCollection_ThrowsArgumentNullException()
        {
            List<Single?> ls = null;
            var caughtException = Assert.Throws<ArgumentNullException>(() => ls!.Max());
        }

        [Fact]
        public void MaxSingleN_WhenEmpty_ReturnsNull()
        {
            List<Single?> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxSingleN_WhenAllNull_ReturnsNull()
        {
            List<Single?> ls = [null, null];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxSingleN_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Single?> ls = [1, null, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxDouble_WhenEmpty_ReturnsNull()
        {
            List<Double> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDouble_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Double> ls = [1, 2.5, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxDoubleN_WhenNullCollection_ThrowsArgumentNullException()
        {
            List<Double?> ls = null;
            var caughtException = Assert.Throws<ArgumentNullException>(() => ls!.Max());
        }

        [Fact]
        public void MaxDoubleN_WhenEmpty_ReturnsNull()
        {
            List<Double?> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDoubleN_WhenAllNull_ReturnsNull()
        {
            List<Double?> ls = [null, null];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDoubleN_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Double?> ls = [1, null, 13, 4.5];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxDecimal_WhenEmpty_ReturnsNull()
        {
            List<Decimal> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDecimal_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Decimal> ls = [1, 2.5m, 13, 4];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxDecimalN_WhenNullCollection_ThrowsArgumentNullException()
        {
            List<Decimal?> ls = null;
            var caughtException = Assert.Throws<ArgumentNullException>(() => ls!.Max());
        }

        [Fact]
        public void MaxDecimalN_WhenEmpty_ReturnsNull()
        {
            List<Decimal?> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDecimalN_WhenAllNull_ReturnsNull()
        {
            List<Decimal?> ls = [null, null];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxDecimalN_WhenNotEmpty_ReturnsLargestValue()
        {
            List<Decimal?> ls = [1, null, 13, 4.5m];
            var max = ls.Max();
            Assert.Equal(13, max);
        }

        [Fact]
        public void MaxString_WhenEmpty_ReturnsNull()
        {
            List<string> ls = [];
            var max = ls.Max();
            Assert.Null(max);
        }

        [Fact]
        public void MaxString_WhenNotEmpty_ReturnsLargestValue()
        {
            List<string> ls = ["asdf", "0123", "jkl;"];
            var max = ls.Max();
            Assert.Equal("jkl;", max);
        }
    }
}
