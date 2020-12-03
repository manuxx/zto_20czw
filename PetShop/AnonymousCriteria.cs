using System;

internal class AnonymousCriteria<T>: Criteria<T> {
    private Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition) {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item) {
        return _condition(item);
    }
}