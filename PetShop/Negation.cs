namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private Criteria<TItem> _innerCriteria;

        public Negation(Criteria<TItem> innerCriteria)
        {
            _innerCriteria = innerCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_innerCriteria.IsSatisfiedBy(item);
        }
    }
}