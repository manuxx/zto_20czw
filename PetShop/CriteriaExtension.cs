using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;

static internal class CriteriaExtension
{
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
    {
        return new Conjuction<TItem>(leftCriteria, rightCriteria);
    }
}
