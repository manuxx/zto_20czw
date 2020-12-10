﻿namespace Training.DomainClasses
{
    public static class CriteriaExtension
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            return new Conjuction<TItem>(leftCriteria, rightCriteria);
        }
    }
}