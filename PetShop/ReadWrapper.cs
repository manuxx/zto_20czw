using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses {
    public class ReadWrapper<T> : IEnumerable<T> {
        private readonly IEnumerable<T> _petsInTheStore;

        public ReadWrapper(IEnumerable<T> petsInTheStore) {
            _petsInTheStore = petsInTheStore;
        }

        public IEnumerator<T> GetEnumerator() {
            return _petsInTheStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}