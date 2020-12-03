using System;

public class AnonymouscCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _condition;

    public AnonymouscCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}