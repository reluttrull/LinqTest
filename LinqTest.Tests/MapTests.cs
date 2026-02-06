using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public class MapTests
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
    }
}
