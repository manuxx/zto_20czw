using System;
using System.Collections;
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
            var cats = new List<Pet>();
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    cats.Add(pet);
                }
            }

            return new ReadOnlyWrapper<Pet>(cats);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var petsToBeSorted = new List<Pet>(_petsInTheStore);
            petsToBeSorted.Sort((x, y) => String.Compare(x.name, y.name, StringComparison.Ordinal));

            return new ReadOnlyWrapper<Pet>(petsToBeSorted);
        }
    }
}