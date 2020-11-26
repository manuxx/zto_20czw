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

        public IEnumerable<Pet> AllCats()
        {

            var cats = _petsInTheStore;

            for (var i = cats.Count - 1; i >= 0; i--)
            {
                if (cats[i].species != Species.Cat)
                    cats.RemoveAt(i);
            }

            return new ReadOnlyWrapper<Pet>(cats);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedList = _petsInTheStore.ToList();
            sortedList.Sort((x, y) => string.CompareOrdinal(x.name, y.name));
            return new ReadOnlyWrapper<Pet>(sortedList);
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