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
            _petsInTheStore = petsInTheStore;
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
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species.Equals(Species.Cat))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);
            sortedPets.Sort((x, y) => String.Compare(x.name, y.name, StringComparison.Ordinal));
            return new ReadOnlyWrapper<Pet>(sortedPets);
        }
    }
}