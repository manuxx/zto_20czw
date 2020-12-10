namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> item1, Criteria<TItem> item2) : base(item1, item2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _item1.IsSatisfiedBy(item) || _item2.IsSatisfiedBy(item);
        }
    }
}