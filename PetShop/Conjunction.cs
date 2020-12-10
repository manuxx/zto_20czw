namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _item1;
        private readonly Criteria<TItem> _item2;

        public Conjunction(Criteria<TItem> item1, Criteria<TItem> item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _item1.IsSatisfiedBy(item) && _item2.IsSatisfiedBy(item);
        }
    }
}