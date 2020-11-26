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
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
        }

        public IEnumerable<Pet> AllMice()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Mouse)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.sex == Sex.Female)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat || pet.species == Species.Dog)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species != Species.Mouse)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.yearOfBirth > 2010)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.yearOfBirth > 2010 && pet.species == Species.Dog)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.sex == Sex.Male && pet.species == Species.Dog)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.yearOfBirth > 2011 || pet.species == Species.Rabbit)
                {
                    yield return pet;
                }
            }
        }
    }
}