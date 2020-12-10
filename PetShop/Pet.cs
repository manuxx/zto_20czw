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
            return new BornAfterCriteria(year);
        }

        public class SpeciesCriteria : Criteria<Pet>
        {
            private readonly Species _species;

            public SpeciesCriteria(Species species)
            {
                _species = species;
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return item.species == _species;
            }
        }

        public class SexCriteria : Criteria<Pet>
        {
            private readonly Sex _sex;

            public SexCriteria(Sex sex)
            {
                _sex = sex;
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return item.sex == _sex;
            }
        }

        public class BornAfterCriteria : Criteria<Pet>
        {
            private readonly int _yearOfBirth;

            public BornAfterCriteria(int yearOfBirth)
            {
                _yearOfBirth = yearOfBirth;
            }

            public override bool IsSatisfiedBy(Pet item)
            {
                return item.yearOfBirth > _yearOfBirth;
            }
        }

        public static Criteria<Pet> IsMale()
        {
            return new SexCriteria(Sex.Male);
        }
    }
}