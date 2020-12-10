namespace Training.DomainClasses
{
    public class Conjuction<TItem> : BinaryCriteria<TItem>
    {
        public Conjuction(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) && _rightCriteria.IsSatisfiedBy(item);
        }
    }
}