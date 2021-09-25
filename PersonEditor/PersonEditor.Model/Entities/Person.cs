using PersonEditor.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonEditor.Model.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        [ForeignKey("Address")]
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }

        public Person(string name, string lastName, DateTime birthday, Gender gender, Address address)
        {
            Name = name;

            LastName = lastName;

            Birthday = birthday;

            Gender = gender;

            Address = address;
        }

        public Person()
        {

        }
    }
}
