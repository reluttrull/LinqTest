using LinqTest;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class UnitTests
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
        public void Average_WhenMultipleIntsAndNonIntegerResult_ReturnsCorrectAverage()
        {
            List<int> nums = [1, 2];
            var avg = nums.Average();
            Assert.Equal(1.5, avg);
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

        [Fact]
        public void Aggregate_WhenThreeTypes_HandlesTransformsCorrectly()
        {
            List<int> ls = [1, 2, 3, 4, 5, 6, 7];
            var agg = ls.Aggregate<int, double, string>((total, next) => total += (double)next / 2, num => num.ToString());
            Assert.IsType<string>(agg);
            Assert.Equal("14", agg);
        }

        public record Person(string Name);
        public class ChildObj : IEquatable<ChildObj>
        {
            public int Id { get; set; }
            public string Property { get; set; } = string.Empty;

            public bool Equals(ChildObj? other)
            {
                return other is not null
                    && Id == other.Id
                    && Property == other.Property;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as ChildObj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Property);
            }
        }
        public class ParentObj
        {
            public int Id { get; set; }
            public List<ChildObj> Children { get; set; } = [];
        }
    }
}
