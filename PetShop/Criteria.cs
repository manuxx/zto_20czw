using System;
using Training.DomainClasses;

static internal class CriteriaExtensions {
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria) {
        return new Conjuction<TItem>(criteria1, criteria);
    }
}

public interface Criteria<TItem> {
    bool IsSatisfiedBy(TItem item);
}