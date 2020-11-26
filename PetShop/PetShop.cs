using System;
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
<<<<<<< HEAD
            return new ReadOnlyWrapper<Pet> (_petsInTheStore);
=======
            return new ReadOnlyWrapper<Pet>(_petsInTheStore);
>>>>>>> c31e63bc092667bef9d5dfb3fed1bb9428cf794a
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
}