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

        private IEnumerable<Pet> All(Predicate<Pet> pred)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pred(pet))
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
            return All(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return All(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return All(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return All(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return All(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            throw new NotImplementedException();
        }
    }
}