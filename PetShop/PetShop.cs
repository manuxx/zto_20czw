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
            return new ReadOnlyWrapper<Pet> (_petsInTheStore);
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
<<<<<<< HEAD
            foreach (var pet in AllPets())
            {
                if (pet.species == Species.Cat)
                    yield return pet;
=======
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
>>>>>>> e860a89a3e03bd1a692c0c921c1273cc3c28dcda
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
<<<<<<< HEAD
            var colectionPets = new List<Pet>(AllPets());
            colectionPets.Sort((x,y)=> x.name.CompareTo(y.name));
            return colectionPets;
=======
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
>>>>>>> e860a89a3e03bd1a692c0c921c1273cc3c28dcda
        }
    }
}