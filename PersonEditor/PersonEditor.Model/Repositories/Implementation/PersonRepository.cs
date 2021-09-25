using PersonEditor.Model.Entities;
using PersonEditor.Model.Repositories;
using PersonEditor.Model.Context;
using System.Linq;
using PersonEditor.Model.Exceptions;
using System;
using Microsoft.EntityFrameworkCore;

namespace PersonAPI.Model.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _dataContext;

        public PersonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Person GetPerson(Guid id)
        {
            var person = _dataContext.Persons.Include(p => p.Address).FirstOrDefault(p => p.Id == id);

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
            var person = _dataContext.Persons.Include(p => p.Address).FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            try
            {
                _dataContext.Addresses.Remove(person.Address);

                _dataContext.Persons.Remove(person);

                _dataContext.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Person UpdatePerson(Guid id, Person personToUpdate)
        {
            var person = _dataContext.Persons.Include(p => p.Address).FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            personToUpdate.Id = person.Id;

            personToUpdate.AddressId = person.AddressId;

            personToUpdate.Address.AddressId = person.Address.AddressId;

            try
            {
                _dataContext.Entry(person.Address).CurrentValues.SetValues(personToUpdate.Address);

                _dataContext.Entry(person).CurrentValues.SetValues(personToUpdate);

                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }
    }
}
