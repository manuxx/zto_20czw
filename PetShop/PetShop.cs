using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlyWrapper<Pet> (_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.name == newPet.name)
                    return;
            } 
            _petsInTheStore.Add(newPet);
        }
    }

    public class ReadOnlyWrapper<TItem> : IEnumerable<TItem>
    {
        private IEnumerable<TItem> _petsInTheStore;

        public ReadOnlyWrapper(IEnumerable<TItem> petsInTheStore)
        {
            _petsInTheStore = petsInTheStore;
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return _petsInTheStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}