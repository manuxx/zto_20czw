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

        public static Criteria<Pet> IsBornAfter(int i)
        {
            return new BornAfterCriteria(i);
        }

        public static Predicate<Pet> IsNotaSpeciesOf(Species species)
        {
            return pet => pet.species != species;
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }
    }

    public class BornAfterCriteria : Criteria<Pet>
    {
        private readonly int _year;

        public BornAfterCriteria(int year)
        {
            _year=year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth>_year;
        }
    }

    public class SexCriteria : Criteria<Pet>
    {
        private readonly Sex _sex;
        public SexCriteria(Sex sex)
        {
            _sex = sex;
        }
        public bool IsSatisfiedBy(Pet item)
        {
            return _sex == item.sex;
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