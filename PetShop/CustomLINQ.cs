using System;
using System.Collections.Generic;
using Training.DomainClasses;

internal static class CustomLINQ
{
    public static IEnumerable<TItem> Which<TItem>(this IEnumerable<TItem> collection, Predicate<TItem> condition)
    {
        foreach (var item in collection)
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}