using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class AggregateTests
    {
        [Fact]
        public void Aggregate_WhenThreeTypes_HandlesTransformsCorrectly()
        {
            List<int> ls = [1, 2, 3, 4, 5, 6, 7];
            var agg = ls.Aggregate<int, double, string>((total, next) => total += (double)next / 2, num => num.ToString());
            Assert.IsType<string>(agg);
            Assert.Equal("14", agg);
        }
    }
}
