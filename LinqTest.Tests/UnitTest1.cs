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
    }
}
