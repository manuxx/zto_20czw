namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _item1;
        protected Criteria<TItem> _item2;

        public BinaryCriteria(Criteria<TItem> item1, Criteria<TItem> item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }

    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> item1, Criteria<TItem> item2) : base(item1, item2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _item1.IsSatisfiedBy(item) && _item2.IsSatisfiedBy(item);
        }
    }
}