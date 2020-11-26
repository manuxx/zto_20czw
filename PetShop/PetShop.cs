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
        public IEnumerable<Pet> AllPets(Func<Pet, bool> filter)
        {
            foreach (Pet pet in _petsInTheStore)
            {
                if (filter(pet))
                {
                    yield return pet;
                }
            }
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
            return this.AllPets((pet => pet.species == Species.Cat));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((pet, pet1) => pet.name.CompareTo(pet1.name));
            return list;
        }


        public IEnumerable<Pet> AllMice()
        {
            return this.AllPets(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return this.AllPets(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return this.AllPets(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return this.AllPets(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return this.AllPets(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return this.AllPets(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return this.AllPets(pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }
        //Test zosta� �le napisany
        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return this.AllPets(pet => pet.yearOfBirth > 2010 || pet.species==Species.Rabbit);
        }
    }
}