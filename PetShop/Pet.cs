using System;

namespace Training.DomainClasses{
    public class Pet{
        public Sex sex;
        public string name{ get; set; }
        public int yearOfBirth{ get; set; }
        public float price{ get; set; }
        public Species species{ get; set; }

        public static Criteria<Pet> IsSpeciesOf(Species species){
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsBornAfter(int year){
            return new BornAfterYearCriteria(year);
        }

        public static Criteria<Pet> IsFemale(){
            return new SexCriteria(Sex.Female);
        }

        public static Predicate<Pet> IsNotSpeciesOf(Species species){
            return pet => pet.species != species;
        }
    }

    public class BornAfterYearCriteria : Criteria<Pet>{
        private readonly int _year;

        public BornAfterYearCriteria(int year){
            _year = year;
        }

        public bool IsSatisfiedBy(Pet pet){
            return pet.yearOfBirth > _year;
        }
    }

    public class SexCriteria : Criteria<Pet>{
        private Sex _sex;

        public SexCriteria(Sex sex){
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet pet){
            return pet.sex == _sex;
        }
    }

    public class SpeciesCriteria : Criteria<Pet>{
        private readonly Species _species;

        public SpeciesCriteria(Species species){
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item){
            return item.species == _species;
        }
    }
}