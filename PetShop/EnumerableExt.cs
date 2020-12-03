using System;
using System.Collections.Generic;
using System.Linq;
using Training.DomainClasses;

static internal class EnumerableExt
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        return items.AllThat(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
            if (criteria.IsSatisfiedBy(item))
                yield return item;
    }
}