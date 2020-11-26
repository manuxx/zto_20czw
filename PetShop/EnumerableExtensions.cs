﻿using System.Collections.Generic;
using Training.DomainClasses;

internal static class EnumerableExtensions{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> items){
        foreach (var item in items)
            yield return item;
    }
}