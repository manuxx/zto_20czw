namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _innerCriteria;

        public Negation(Criteria<TItem> innerCriteria)
        {
            _innerCriteria = innerCriteria;
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return ! _innerCriteria.IsSatisfiedBy(item);
        }
    }
}