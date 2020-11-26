using System.Collections.Generic;

namespace Training.DomainClasses
{
    internal static class EnumerableExt
    {
        public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> items){
            foreach (var item in items)
                yield return item;
        }
    }
}