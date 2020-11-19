using System;
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
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
            if (_petsInTheStore.IndexOf(newPet) == -1)
            {
                bool existPetWithThatName = false;
                foreach (var pet in _petsInTheStore)
                {
                    if (pet.name == newPet.name)
                    {
                        existPetWithThatName = true;
                        break;
                    }
                }
                if (!existPetWithThatName)
                    _petsInTheStore.Add(newPet);
            }
        }
    }
}