using System.Collections.Generic;
using Training.DomainClasses;

namespace Training.DomainClasses
{
    static internal class EnumerableExt
    {
        public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
                yield return item;
        }


        public static IEnumerable<Pet> PetsBornAfter(this IEnumerable<Pet> pets, int year)
        {
            foreach (var pet in pets)
            {
                if (pet.yearOfBirth > year)
                    yield return pet;
            }
        }

        public static IEnumerable<Pet> PetsBySpecies(this IEnumerable<Pet> pets, Species species)
        {
            foreach (var pet in pets)
            {
                if (pet.species == species)
                    yield return pet;
            }
        }

        public static IEnumerable<Pet> PetsBySex(this IEnumerable<Pet> pets, Sex sex)
        {
            foreach (var pet in pets)
            {
                if (pet.sex == sex)
                    yield return pet;
            }
        }
    }
}
