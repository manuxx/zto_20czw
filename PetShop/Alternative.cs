namespace Training.DomainClasses
{
    namespace Training.DomainClasses
    {
        public class Alternative<T> : Criteria<T> {
            private Criteria<T> _criteriaOne;
            private Criteria<T> _criteriaTwo;

            public Alternative(Criteria<T> criteriaOne, Criteria<T> criteriaTwo)
            {
                _criteriaOne = criteriaOne;
                _criteriaTwo = criteriaTwo;
            }

            public bool IsSatisfiedBy(T item)
            {
                return _criteriaOne.IsSatisfiedBy(item) || _criteriaTwo.IsSatisfiedBy(item);
            }
        }
    }
}