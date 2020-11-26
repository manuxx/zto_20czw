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
            return new ReadOnlySet (_petsInTheStore);
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

    public class ReadOnlySet : IEnumerable<Pet>
    {
        private IList<Pet> _petsInTheStore;

        public ReadOnlySet(IList<Pet> petsInTheStore)
        {
            _petsInTheStore = petsInTheStore;
            
        }
        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var item in _petsInTheStore)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}