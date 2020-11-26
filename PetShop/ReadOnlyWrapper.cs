using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DomainClasses
{
    public class ReadOnlyWrapper<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _items;

        public ReadOnlyWrapper(IEnumerable<T> items)
        {
            _items = items;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
