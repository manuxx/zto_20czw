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
            var filter = new Func<Pet, bool>((Pet pet) => pet.species == Species.Cat);
            return _petsInTheStore.FilterEnumerable(filter);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.sex == Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.sex == Sex.Female);

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllPetsBornAfter2010().FilterEnumerable((Pet pet) => pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.FilterEnumerable((Pet pet) => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }
}