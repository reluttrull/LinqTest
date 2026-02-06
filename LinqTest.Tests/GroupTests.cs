using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class GroupTests
    {
        [Fact]
        public void GroupBy_WhenSplitIntoTwoGroups_ShouldReturnTwoGroupings()
        {
            List<int> ls = [0, 1, 1, 0, 1];
            var groups = ls.GroupBy(x => x);
            Assert.Equal(2, groups.Count());
        }

        [Fact]
        public void GroupBy_AfterSplitIntoGroupings_ShouldBeAbleToSelectMany()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var groups = ls.GroupBy(x => x % 3);
            Assert.Equal(3, groups.Count());
            var select = groups.SelectMany(g => g);
            Assert.Equal(5, select.Count());
        }
    }
}
