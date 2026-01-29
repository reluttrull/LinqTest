using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinqTest
{
    public static class Group
    {
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TElement>(this IEnumerable<TElement> collection, Func<TElement, TKey> transformation)
            where TKey : notnull
        {
            Dictionary<TKey, List<TElement>> dict = new();
            foreach (TElement element in collection)
            {
                TKey key = transformation(element);
                if (dict.TryGetValue(key, out List<TElement>? value))
                {
                    value.Add(element);
                }
                else
                {
                    dict.Add(key, [element]);
                }
            }
            return dict.Select(kvp => new IGrouping<TKey, TElement>(kvp));
        }
        public class IGrouping<TKey, TElement>(KeyValuePair<TKey, List<TElement>> kvp) : IEnumerable<TElement>
        {
            public TKey Key { get; set; } = kvp.Key;
            private List<TElement> elements = kvp.Value;

            public IEnumerator<TElement> GetEnumerator()
            {
                foreach (TElement element in elements)
                {
                    yield return element;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
