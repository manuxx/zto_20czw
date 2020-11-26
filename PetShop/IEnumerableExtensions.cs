using System.Collections.Generic;

static internal class IEnumerableExtensions
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            yield return item;
        }
    }
}