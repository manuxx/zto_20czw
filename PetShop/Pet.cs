using System;
using System.Runtime.InteropServices.WindowsRuntime;

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

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornCriteria(year);
        }

        public static Criteria<Pet> IsNotASpeciesOf(Species species)
        {
            return new NotSpeciesCriteria(species);
        }
    }

    public class NotSpeciesCriteria : Criteria<Pet>
    {
        private readonly Species _species;

        public NotSpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species != _species;
        }
    }

    public class BornCriteria : Criteria<Pet>
    {
        private readonly int _year;

        public BornCriteria(int year)
        {
            _year = year;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > _year;
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
            return item.sex == _sex;
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