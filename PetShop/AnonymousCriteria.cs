using System;

namespace Training.DomainClasses
{
    internal class AnonymousCriteria<TItem> : Criteria<TItem>
    {
        private readonly Predicate<TItem> _condition;

        public AnonymousCriteria(Predicate<TItem> condition)
        {
            _condition = condition;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _condition(item);
        }
    }
}