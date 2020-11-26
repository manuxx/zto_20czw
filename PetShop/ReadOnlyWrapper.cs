using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses{
    public class ReadOnlyWrapper<T> : IEnumerable<T>{
        
        private readonly IList<T> _items;

        public ReadOnlyWrapper(IList<T> items){
            _items = items;
        }

        public IEnumerator<T> GetEnumerator(){
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }
    }
}