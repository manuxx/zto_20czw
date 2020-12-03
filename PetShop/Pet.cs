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

        public static Criteria<Pet> IsSpecies(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Predicate<Pet> IsNotSpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornCriteria(year, BornCriteria.After);
        }
    }

    public class BornCriteria : Criteria<Pet>
    {
        private readonly int _year;
        private readonly YearRelation _relation;

        public BornCriteria(int year, YearRelation relation)
        {
            _year = year;
            _relation = relation;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _relation.IsValidFor(pet.yearOfBirth, _year);
        }

        public static readonly YearRelation After = new YearRelation((birthyear, year) => birthyear > year);
    }

    public class YearRelation
    {
        private readonly Func<int, int, bool> _op;

        public YearRelation(Func<int, int, bool> op)
        {
            _op = op;
        }

        public bool IsValidFor(int year, int cmpYear)
        {
            return _op(year, cmpYear);
        }
    }

    public class SexCriteria : Criteria<Pet>
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

    public class SpeciesCriteria : Criteria<Pet>
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