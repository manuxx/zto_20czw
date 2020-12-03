using System;
using System.Collections.Generic;
using Training.DomainClasses;

static internal class EnumerableExt
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
    public static Predicate<Pet> IsNotASpeciesOf(Species species)
    {
        return pet => pet.species != species;
    }
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.AllThat(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
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