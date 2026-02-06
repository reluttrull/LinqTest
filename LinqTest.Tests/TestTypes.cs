using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinqTest.Tests
{
    [ExcludeFromCodeCoverage]
    public record Person(string Name);

    [ExcludeFromCodeCoverage]
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

    [ExcludeFromCodeCoverage]
    public class ParentObj
    {
        public int Id { get; set; }
        public List<ChildObj> Children { get; set; } = [];
    }
}
