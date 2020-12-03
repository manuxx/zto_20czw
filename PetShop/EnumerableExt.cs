using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class EnumerableExt
    {
        public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Predicate<TItem> condition)
        {
            foreach (var item in items)
                if (condition(item))
                    yield return item;
        }
    }
}