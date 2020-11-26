using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumeralbeExt
{
    public static IEnumerable<Titem> OneAtTime<Titem>(this IEnumerable<Titem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}