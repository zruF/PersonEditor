using Microsoft.AspNetCore.Mvc;
using PersonEditor.Model.Entities;
using PersonEditor.Web.Controllers.DTO;
using PersonEditor.Web.WorkContext;
using Microsoft.AspNetCore.Http;
using PersonEditor.Model.Exceptions;
using PersonEditor.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PersonEditor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IWorkContextCreatable workContextCreator;

        protected IWorkContext WorkContext { get; private set; }

        public PersonController(IWorkContextCreatable workContextCreator)
        {
            this.workContextCreator = workContextCreator;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            WorkContext = workContextCreator.Create(context.HttpContext);

            return base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// Returns a person
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <response code="200">Person</response>
        /// <response code="204">Person not found</response>
        [HttpGet]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromQuery] Guid id)
        {
            try
            {
                var person = WorkContext.PersonRepository.GetPerson(id);

                return Ok(person);
            }
            catch (PersonNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a person
        /// <param name="person">Person to create</param>
        /// </summary>
        /// <response code="201">Person was successfully created</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonRequestModel), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] PersonRequestModel person)
        {
            var personId = WorkContext.PersonRepository.CreatePerson(new Person(person.Name, person.LastName, person.Birthday, person.Gender, 
                new Address(person.Address.City, person.Address.PostalCode, person.Address.Country, person.Address.Street)));

            return StatusCode(StatusCodes.Status201Created, personId);
        }

        /// <summary>
        /// Updated a person
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <param name="person">Person to update</param>
        /// <response code="200">Person was successfully updated</response>
        /// <response code="400">Person couldn't be updated</response>
        /// <response code="404">Person not found</response>
        [HttpPut]
        [ProducesResponseType(typeof(PersonRequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromQuery] Guid id, [FromBody] PersonRequestModel person)
        {
            try
            {
                var updatedPerson = WorkContext.PersonRepository.UpdatePerson(id, new Person(person.Name, person.LastName, person.Birthday, person.Gender,
                    new Address(person.Address.City, person.Address.PostalCode, person.Address.Country, person.Address.Street)));

                return Ok(updatedPerson);
            }
            catch (PersonNotFoundException)
            {
                return NotFound("Person not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="id">Id of person</param>
        /// <response code="204">Person was successfully deleted</response>
        /// <response code="400">Person couldn't be deleted</response>
        /// <response code="404">Person not found</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromQuery] Guid id)
        {
            try
            {
                WorkContext.PersonRepository.DeletePerson(id);

                return NoContent();
            }
            catch(PersonNotFoundException)
            {
                return NotFound("Person not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
