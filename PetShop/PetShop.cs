using System;
using System.Collections;
using System.Collections.Generic;

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
            return new ReadOnlySet(_petsInTheStore); //_petsInTheStore.OneAtATime();
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
        private readonly IList<Pet> _petsInTheStore;

        public ReadOnlySet(IList<Pet> petsInTheStore)
        {
            _petsInTheStore = petsInTheStore;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var pet in _petsInTheStore)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}