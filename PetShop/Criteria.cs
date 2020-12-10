using System;
using Training.DomainClasses;

public abstract class Criteria<TItem> {
    public abstract bool IsSatisfiedBy(TItem item);

    public Criteria<TItem> And(Criteria<TItem> criteria) {
        return new Conjuction<TItem>(this, criteria);
    }
}