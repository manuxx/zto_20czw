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
            return EnumerableExt.AllThat(pet => pet.species == Species.Cat, _petsInTheStore);
        }
        public IEnumerable<Pet> AllMice()
        {
            return EnumerableExt.AllThat(pet => pet.species == Species.Mouse, _petsInTheStore);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return EnumerableExt.AllThat(pet => pet.sex == Sex.Female, _petsInTheStore);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return EnumerableExt.AllThat(pet => pet.species == Species.Cat || pet.species == Species.Dog, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return EnumerableExt.AllThat(pet => pet.species != Species.Mouse, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return EnumerableExt.AllThat(pet => pet.yearOfBirth > 2010, _petsInTheStore);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return EnumerableExt.AllThat(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010, _petsInTheStore);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return EnumerableExt.AllThat(pet => pet.species == Species.Dog && pet.sex == Sex.Male, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return EnumerableExt.AllThat(pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
        }
    }
}