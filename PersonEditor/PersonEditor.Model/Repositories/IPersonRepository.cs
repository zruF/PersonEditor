using PersonEditor.Model.Entities;
using System;

namespace PersonEditor.Model.Repositories
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Returns a person by id
        /// </summary>
        /// <param name="id">Id of the person</param>
        /// <returns>Person</returns>
        public Person GetPerson(Guid id);

        /// <summary>
        /// Creates a person
        /// </summary>
        /// <param name="person">Object of person to create</param>
        public Guid CreatePerson(Person person);

        /// <summary>
        /// Deletes a person by id
        /// </summary>
        /// <param name="id">Id of the person</param>
        /// <returns>Person</returns>
        public void DeletePerson(Guid id);

        /// <summary>
        /// Updates a person by id
        /// </summary>
        /// <param name="id">Id of the person</param>
        /// <param name="person">Object of person with properties to update</param>
        /// <returns>Person</returns>
        public Person UpdatePerson(Guid id, Person person);
    }
}
