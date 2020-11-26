using System;
using System.Collections.Generic;
using Training.DomainClasses;

internal static class EnumerableExt
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
    {
        foreach (var item in enumerable)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}