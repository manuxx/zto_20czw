namespace Training.DomainClasses
{
    namespace Training.DomainClasses
    {
        public class Alternative<T> : ICriteria<T> {
            private ICriteria<T> _criteriaOne;
            private ICriteria<T> _criteriaTwo;

            public Alternative(ICriteria<T> criteriaOne, ICriteria<T> criteriaTwo)
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