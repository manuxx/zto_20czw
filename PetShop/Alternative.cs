namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {

        private readonly Criteria<TItem> _leftCriteria;
        private readonly Criteria<TItem> _rightCriteria;

        public Alternative(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) || _rightCriteria.IsSatisfiedBy(item);
        }
    }
}