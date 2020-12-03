using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    static internal class EnumerableExt
    {
        public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Predicate<TItem> condition)
        {
            return items.AllThat(new AnonymousCriteria<TItem>(condition));
        }

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

        public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
        {
            foreach (var item in items)
                if (criteria.IsSatisfiedBy(item))
                    yield return item;
        }
    }

    public interface Criteria<TItem>
    {
        bool IsSatisfiedBy(TItem item);
    }
}