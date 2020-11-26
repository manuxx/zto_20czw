using System.Collections.Generic;
using Training.DomainClasses;

internal static class EnumerableExt {
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> petsInTheStore) {
        foreach (var pet in petsInTheStore) {
            yield return pet;
        }
    }
}