using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class SortTests
    {
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
    }
}
