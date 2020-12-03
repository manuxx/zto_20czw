using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class EnumerableExt
    {
        public static IEnumerable<Pet> AllThat(this IList<Pet> pets, Predicate<Pet> condition)
        {
            foreach (var pet in pets)
                if (condition(pet))
                    yield return pet;
        }
    }
}