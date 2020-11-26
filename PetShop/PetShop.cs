using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IEnumerable<Pet> AllCats(){
            foreach (var pet in _petsInTheStore) {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName(){
            var pets = new List<Pet>(_petsInTheStore);
            pets.Sort(((pet1, pet2) => String.Compare(pet1.name, pet2.name, StringComparison.Ordinal)));
            return new ReadOnlyWrapper<Pet>(pets);
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