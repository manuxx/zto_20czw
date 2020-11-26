using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class ReadOnlyWrapper<TItem> : IEnumerable<TItem>
    {
        private readonly IList<TItem> _items;

        public ReadOnlyWrapper(IList<TItem> items)
        {
            _items = items;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
