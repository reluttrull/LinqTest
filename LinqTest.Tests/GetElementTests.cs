using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class GetElementTests
    {
        [Fact]
        public void ElementAt_WhenIndexLessThanZero_ThrowsException()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(() => ls.ElementAt(-1));
        }

        [Fact]
        public void ElementAt_WhenIndexTooBig_ThrowsException()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(() => ls.ElementAt(5));
        }

        [Fact]
        public void ElementAt_WhenCollectionNotIList_ReturnsElementAtIndex()
        {
            string str = "123";
            int element = str.ElementAt(1);
            Assert.Equal('2', element);
        }

        [Fact]
        public void ElementAtOrDefault_WhenIndexLessThanZero_ReturnsNull()
        {
            List<string> ls = ["1", "2"];
            var element = ls.ElementAtOrDefault(-1);
            Assert.Null(element);
        }

        [Fact]
        public void ElementAtOrDefault_WhenIndexTooBig_ReturnsNull()
        {
            List<string> ls = ["1", "2"];
            var element = ls.ElementAtOrDefault(3);
            Assert.Null(element);
        }

        [Fact]
        public void ElementAtOrDefault_WhenCollectionNotIList_ReturnsElementAtIndex()
        {
            string str = "123";
            int element = str.ElementAtOrDefault(1);
            Assert.Equal('2', element);
        }

        [Fact]
        public void First_WhenCollectionEmpty_ThrowsException()
        {
            List<int> ls = [];
            var caughtException = Assert.Throws<InvalidOperationException>(() => ls.First());
        }

        [Fact]
        public void First_WhenCollectionNotEmpty_ReturnsFirstItem()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.First();
            Assert.Equal(1, first);
        }

        [Fact]
        public void First_WhenPredicatePassedIn_AppliesFilterFirst()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.First(x => x > 2);
            Assert.Equal(3, first);
        }

        [Fact]
        public void FirstOrDefault_WhenCollectionEmpty_ReturnsNull()
        {
            List<string> ls = [];
            var first = ls.FirstOrDefault();
            Assert.Null(first);
        }

        [Fact]
        public void FirstOrDefault_WhenCollectionNotEmpty_ReturnsFirstItem()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.FirstOrDefault();
            Assert.Equal(1, first);
        }

        [Fact]
        public void FirstOrDefault_WhenPredicatePassedIn_AppliesFilterFirst()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.FirstOrDefault(x => x > 2);
            Assert.Equal(3, first);
        }

        [Fact]
        public void FirstOrDefaultWDef_WhenCollectionEmpty_ReturnsDefault()
        {
            List<string> ls = [];
            var first = ls.FirstOrDefault("default");
            Assert.Equal("default", first);
        }

        [Fact]
        public void FirstOrDefaultWDef_WhenCollectionNotEmpty_ReturnsFirstItem()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.FirstOrDefault(-1);
            Assert.Equal(1, first);
        }

        [Fact]
        public void FirstOrDefaultWDef_WhenPredicatePassedIn_AppliesFilterFirst()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var first = ls.FirstOrDefault(x => x > 2, -1);
            Assert.Equal(3, first);
        }

        [Fact]
        public void Single_WhenMultipleMatches_ThrowsException()
        {
            List<string> ls = ["abc", "def", "abc"];
            var caughtException = Assert.Throws<InvalidOperationException>(() => ls.Single(x => x == "abc"));
        }

        [Fact]
        public void Single_WhenNoMatches_ThrowsException()
        {
            List<string> ls = ["abc", "def", "abc"];
            var caughtException = Assert.Throws<InvalidOperationException>(() => ls.Single(x => x == string.Empty));
        }

        [Fact]
        public void Single_WhenOneMatch_ReturnsMatch()
        {
            List<string> ls = ["abc", "def", "abc"];
            var single = ls.Single(x => x == "def");
            Assert.Equal("def", single);
        }

        [Fact]
        public void SingleOrDefault_WhenMultipleMatches_ThrowsException()
        {
            List<string> ls = ["abc", "def", "abc"];
            var caughtException = Assert.Throws<InvalidOperationException>(() => ls.SingleOrDefault(x => x == "abc"));
        }

        [Fact]
        public void SingleOrDefault_WhenNoMatches_ReturnsNull()
        {
            List<string> ls = ["abc", "def", "abc"];
            var single = ls.SingleOrDefault(x => x == string.Empty);
            Assert.Null(single);
        }

        [Fact]
        public void SingleOrDefault_WhenOneMatch_ReturnsMatch()
        {
            List<string> ls = ["abc", "def", "abc"];
            var single = ls.SingleOrDefault(x => x == "def");
            Assert.Equal("def", single);
        }
    }
}
