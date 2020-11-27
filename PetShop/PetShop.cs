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
            var colectionPets = new List<Pet>(AllPets());
            colectionPets.Sort((x,y)=> x.name.CompareTo(y.name));
            return colectionPets;
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
                if (pet.species == Species.Cat || pet.species==Species.Dog)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            throw new NotImplementedException();
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