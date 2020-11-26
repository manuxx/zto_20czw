using System;
using System.Collections.Generic;
using System.Linq;

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
            return new ReadOnlyWrapper<Pet>(_petsInTheStore);
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

        public IEnumerable<Pet> AllCats()
        {
            IList<Pet> _catsList = new List<Pet>();
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    _catsList.Add(pet);
                }
            }
            return new ReadOnlyWrapper<Pet>(_catsList);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> _pets = new List<Pet>(_petsInTheStore);
            _pets.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return _pets;
        }
    }
}