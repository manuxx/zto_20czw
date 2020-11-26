using System;
using System.Collections.Generic;
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
    public static IEnumerable<TItem> FilterEnumerable<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> filter)
    {
        foreach (var item in items)
        {
            if (filter(item)) yield return item;
        }
    }
}