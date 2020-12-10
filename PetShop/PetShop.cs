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

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Cat));
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllThat(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Cat).Or(Pet.IsSpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllThat(new Negation<Pet>(Pet.IsSpeciesOf(Species.Mouse)));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllThat(Pet.IsBornAfter(2010).And(Pet.IsSpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Dog).And(Pet.IsMale()));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Rabbit).Or( Pet.IsBornAfter(2011)));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
        }
    }
}