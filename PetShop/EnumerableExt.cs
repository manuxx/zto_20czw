using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableExt
{
    public static IEnumerable<TItem> OneAtTime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}