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

        public IEnumerable<Pet> AllCats() {
            foreach (var pet in _petsInTheStore) {
                if (pet.species.Equals(Species.Cat)) {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName() {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort(((pet, pet1) => String.Compare(pet.name, pet1.name, StringComparison.Ordinal)));
            return new ReadOnlyWrapper<Pet>(list);
        }
    }
}