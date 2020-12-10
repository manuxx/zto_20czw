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

        public static ICriteria<Pet> IsSpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static ICriteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static ICriteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }

        public static ICriteria<Pet> IsNotASpeciesOf(Species species)
        {
            return new Negation<Pet>(IsSpeciesOf(species));
        }
    }

    public class Negation<T> : ICriteria<T> {
        private ICriteria<T> _criteria;

        public Negation(ICriteria<T> criteria) {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(T item) {
            return !_criteria.IsSatisfiedBy(item);
        }
    }

    public class BornAfterCriteria : ICriteria<Pet>
    {
        private readonly int _year;
        public BornAfterCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _year;
        }
    }

    public class SexCriteria : ICriteria<Pet>
    {
        private readonly Sex _sex;
        public SexCriteria(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == _sex;
        }
    }

    public class SpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public SpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == _species;
        }
    }
}