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
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = _petsInTheStore.ToList();
            list.Sort((x, y) => String.Compare(x.name, y.name, StringComparison.Ordinal));
            return new ReadOnlyWrapper<Pet>(list);
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.PetsBySpecies(Species.Mouse);
        }


        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.yearOfBirth > 2011 || pet.species == Species.Rabbit)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.PetsBySpecies(Species.Dog).PetsBySex(Sex.Male);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.PetsBySpecies(Species.Dog).PetsBornAfter(2010);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.PetsBornAfter(2010);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species != Species.Mouse)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.PetsBySpecies(Species.Dog).Concat(_petsInTheStore.PetsBySpecies(Species.Cat));
        }


        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.PetsBySex(Sex.Female);
        }
    }
}