namespace Training.DomainClasses
{
    namespace Training.DomainClasses
    {
        public class Alternative<T> : Criteria<T> {
            private Criteria<T> _criteriaLeft;
            private Criteria<T> _criteriaRight;

            public Alternative(Criteria<T> criteriaLeft, Criteria<T> criteriaRight)
            {
                _criteriaLeft = criteriaLeft;
                _criteriaRight = criteriaRight;
            }

            public bool IsSatisfiedBy(T item)
            {
                return _criteriaLeft.IsSatisfiedBy(item) || _criteriaRight.IsSatisfiedBy(item);
            }
        }
    }
}