using System;
using System.Collections.Generic;

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
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => String.Compare(pet.name, pet1.name, StringComparison.Ordinal));
            return list;
        }

        public IEnumerable<Pet> AllMice()
        {
            return new ReadOnlyWrapper<Pet>(_petsInTheStore.Filter(pet => pet.species.Equals(Species.Mouse)));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return new ReadOnlyWrapper<Pet>(_petsInTheStore.Filter(pet => pet.sex.Equals(Sex.Female)));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return new ReadOnlyWrapper<Pet>(_petsInTheStore.Filter(pet => pet.species.Equals(Species.Dog) || pet.species.Equals(Species.Cat)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return new ReadOnlyWrapper<Pet>(_petsInTheStore.Filter(pet => !pet.species.Equals(Species.Mouse)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            throw new NotImplementedException();
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