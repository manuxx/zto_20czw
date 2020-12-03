using System;

namespace Training.DomainClasses
{
    public class Pet 
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<Pet> IsSpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Predicate<Pet> IsBornAfter(int i)
        {
            return pet => pet.yearOfBirth > i;
        }

        public static Predicate<Pet> IsNotaSpeciesOf(Species species)
        {
            return pet => pet.species != species;
        }

        public static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }
    }

    public class SpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;
        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species == _species;
        }
    }
}