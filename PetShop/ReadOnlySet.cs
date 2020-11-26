using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<T> : IEnumerable<T>
    {
        private readonly IList<T> _pets;

        public ReadOnlySet(IList<T> pets)
        {
            _pets = pets;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}