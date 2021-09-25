using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonEditor.Model.Entities
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressId { get; set; }

        public string City { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public Person Person { get; set; }

        public Address(string city, int postalCode, string country, string street)
        {
            City = city;

            PostalCode = postalCode;

            Country = country;

            Street = street;
        }
    }
}
