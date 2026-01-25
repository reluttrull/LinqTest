using LinqTest;

namespace LinqTest.Tests
{
    public class UnitTest1
    {
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
        public void Where_WhenFiltered_SuccessfullyFilters()
        {
            List<int> ls = [1, 2, 3, 4, 5];
            var where = ls.Where(x => x % 2 == 0);
            Assert.Equal(2, where.Count());
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

        public record Person(string Name);
    }
}
