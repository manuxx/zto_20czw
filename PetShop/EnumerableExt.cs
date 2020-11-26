using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableExt
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> items)
    {
        foreach (var item in items)
            yield return item;
    }
}