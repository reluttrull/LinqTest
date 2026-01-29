using LinqTest;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class UnitTest1
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
            ReadOnlyCollection<int> coll = [1, 2, 3, 4, 5];
            int element = coll.ElementAt(3);
            Assert.Equal(4, element);
        }

        [Fact]
        public void Select_WhenTResultAndTSourceEqual_SuccessfullyTransforms()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var select = ls.Select(x => x * 2);
            Assert.Equal<int>(select, [2, 4, 6, 8, 10]);
        }

        [Fact]
        public void Select_WhenDifferentTResultAndTSource_ReturnsCorrectType()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var select = ls.Select(x => x.ToString());
            Assert.IsType<string>(select.ElementAt(0));
        }

        [Fact]
        public void SelectMany_WhenDifferentTResultAndTSource_ReturnsCorrectType()
        {
            List<ParentObj> ls = [
                new() {
                    Children = [
                        new() {
                            Property = "asdf"
                        },
                        new() {
                            Property = "jkl;"
                        }
                    ]
                },
                new() {
                    Children = [
                        new() {
                            Property = "123"
                        }
                    ]
                }
            ];
            var select = ls.SelectMany(x => x.Children);
            Assert.Equal(3, select.Count());
        }

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
        public void OrderBy_WhenIComparable_SuccessfullyOrdersAsc()
        {
            List<Person> people = [new Person("Larry"), new Person("Allison"), new Person("Sam")];
            var sorted = people.OrderBy(p => p.Name);
            Assert.Equal("Allison", sorted.ElementAt(0).Name);
            Assert.Equal("Sam", sorted.ElementAt(2).Name);
        }

        [Fact]
        public void OrderByDescending_WhenIComparable_SuccessfullyOrdersDesc()
        {
            List<Person> people = [new Person("Larry"), new Person("Allison"), new Person("Sam")];
            var sorted = people.OrderByDescending(p => p.Name);
            Assert.Equal("Sam", sorted.ElementAt(0).Name);
            Assert.Equal("Allison", sorted.ElementAt(2).Name);
        }

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

        public record Person(string Name);
        public class ChildObj
        {
            public int Id { get; set; }
            public string Property { get; set; } = string.Empty;
        }
        public class ParentObj
        {
            public int Id { get; set; }
            public List<ChildObj> Children { get; set; } = [];
        }
    }
}
