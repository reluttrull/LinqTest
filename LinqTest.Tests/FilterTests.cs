using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class FilterTests
    {
        [Fact]
        public void Where_WhenFiltered_SuccessfullyFilters()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var where = ls.Where(x => x % 2 == 0);
            Assert.Equal(2, where.Count());
        }

        [Fact]
        public void Any_WhenNoneMatchPredicate_ReturnsFalse()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var any = ls.Any(x => x > 5);
            Assert.False(any);
        }

        [Fact]
        public void Any_WhenAtLeastOneMatchesPredicate_ReturnsTrue()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var any = ls.Any(x => x % 2 == 0);
            Assert.True(any);
        }


        [Fact]
        public void All_WhenOnlySomeMatchPredicate_ReturnsFalse()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var all = ls.All(x => x > 2);
            Assert.False(all);
        }

        [Fact]
        public void All_WhenAllMatchPredicate_ReturnsTrue()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var all = ls.All(x => x > 0);
            Assert.True(all);
        }

        [Fact]
        public void Contains_WhenContainsItem_ReturnsTrue()
        {
            List<ChildObj> ls = [
                new ChildObj() { Id = 1, Property = "asdf" },
                new ChildObj() { Id = 2, Property = "jkl;" }
            ];
            var contains = ls.Contains<ChildObj>(new ChildObj() { Id = 2, Property = "jkl;" });
            Assert.True(contains);
        }

        [Fact]
        public void Contains_WhenDoesNotContainItem_ReturnsFalse()
        {
            List<ChildObj> ls = [
                new ChildObj() { Id = 1, Property = "asdf" },
                new ChildObj() { Id = 2, Property = "jkl;" }
            ];
            var contains = ls.Contains<ChildObj>(new ChildObj() { Id = 2, Property = "asdf" });
            Assert.False(contains);
        }

        [Fact]
        public void Distinct_WhenDuplicates_SkipsDuplicates()
        {
            List<ChildObj> ls = [
                new ChildObj() { Id = 2, Property = "jkl;" },
                new ChildObj() { Id = 1, Property = "asdf" },
                new ChildObj() { Id = 2, Property = "jkl;" },
                new ChildObj() { Id = 2, Property = "jkl;" }
            ];
            var distinct = ls.Distinct();
            Assert.Equal(2, distinct.Count());
        }

        [Fact]
        public void Distinct_WhenEmpty_ReturnsEmpty()
        {
            List<ChildObj> ls = [];
            var distinct = ls.Distinct();
            Assert.Empty(distinct);
        }
    }
}
