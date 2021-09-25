using PersonEditor.Model.Entities;
using PersonEditor.Model.Repositories;
using PersonEditor.Model.Context;
using System.Linq;
using PersonEditor.Model.Exceptions;
using System;

namespace PersonAPI.Model.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _dataContext;

        internal PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Person GetPerson(Guid id)
        {
            var person = _dataContext.Persons.FirstOrDefault(p => p.Id == id);

            if(person == null)
            {
                throw new PersonNotFoundException();
            }

            return person;
        }

        public Guid CreatePerson(Person person)
        {
            _dataContext.Persons.Add(person);

            _dataContext.SaveChanges();

            return person.Id;
        }

        public void DeletePerson(Guid id)
        {
            var person = _dataContext.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            try
            {
                _dataContext.Persons.Remove(person);
            }
            catch(Exception ex)
            {
                throw;
            }

            _dataContext.SaveChanges();
        }

        public Person UpdatePerson(Guid id, Person personToUpdate)
        {
            var person = _dataContext.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            personToUpdate.Id = id;

            var address = _dataContext.Addresses.FirstOrDefault(a => a.AddressId == person.AddressId);

            personToUpdate.AddressId = address.AddressId;

            personToUpdate.Address.AddressId = address.AddressId;

            _dataContext.Entry(address).CurrentValues.SetValues(personToUpdate.Address);

            _dataContext.Entry(person).CurrentValues.SetValues(personToUpdate);

            _dataContext.SaveChanges();

            personToUpdate.Address = address;

            return person;
        }
    }
}
