using System;

internal class AnnymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _condition;

    public AnnymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}