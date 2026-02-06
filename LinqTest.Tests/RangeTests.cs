using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class RangeTests
    {
        [Fact]
        public void Take_WhenCountLargerThanCollection_ReturnsAllInCollection()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var take = nums.Take(8);
            Assert.Equal(6, take.Count());
        }

        [Fact]
        public void Take_WhenCountSmallerThanCollection_ReturnsOnlyCountNum()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var take = nums.Take(4);
            Assert.Equal(4, take.Count());
            Assert.Equal(1, take.ElementAt(0));
        }

        [Fact]
        public void TakeWhile_WhenAllMeetCondition_ReturnsAllInCollection()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var take = nums.TakeWhile(n => n < 7);
            Assert.Equal(6, take.Count());
        }

        [Fact]
        public void TakeWhile_WhenNoneMeetCondition_ReturnsEmptyCollection()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var take = nums.TakeWhile(n => n > 7);
            Assert.Empty(take);
        }

        [Fact]
        public void TakeWhile_WhenSomeMeetCondition_ReturnsOnlyUpToThatPoint()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var take = nums.TakeWhile(n => n < 4);
            Assert.Equal(3, take.Count());
            Assert.Equal(1, take.ElementAt(0));
        }

        [Fact]
        public void Skip_WhenCountLargerThanCollection_ReturnsEmpty()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var skip = nums.Skip(8);
            Assert.Empty(skip);
        }

        [Fact]
        public void Skip_WhenCountSmallerThanCollection_ReturnsRemainingItems()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var skip = nums.Skip(4);
            Assert.Equal(2, skip.Count());
            Assert.Equal(5, skip.ElementAt(0));
        }

        [Fact]
        public void Skip_WhenCountLessThanZero_ReturnsAllItems()
        {
            List<int> nums = [1, 2, 3, 4, 5, 6];
            var skip = nums.Skip(-1);
            Assert.Equal(6, skip.Count());
            Assert.Equal(1, skip.ElementAt(0));
        }
    }
}
