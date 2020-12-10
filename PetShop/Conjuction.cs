namespace Training.DomainClasses
{
    namespace Training.DomainClasses
    {
        public class Conjunction<T> : ICriteria<T> {
            private ICriteria<T> _criteriaOne;
            private ICriteria<T> _criteriaTwo;

            public Conjunction(ICriteria<T> criteriaOne, ICriteria<T> criteriaTwo)
            {
                _criteriaOne = criteriaOne;
                _criteriaTwo = criteriaTwo;
            }

            public bool IsSatisfiedBy(T item)
            {
                return _criteriaOne.IsSatisfiedBy(item) && _criteriaTwo.IsSatisfiedBy(item);
            }
        }
    }
}